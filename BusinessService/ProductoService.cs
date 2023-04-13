using BusinessEntity;
using BusinessService1.impl;
using DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1
{
    public class ProductoService : IProductoService
    {
        base1Entities _repositorio;
        private readonly FacturaService _facturaService;
        DetalleFacturaService _detalleFacturasService;
        public ProductoService(FacturaService facturaService, DetalleFacturaService detalleFacturasService)
        {
            _facturaService = facturaService;
            _repositorio = new base1Entities();
            _detalleFacturasService = detalleFacturasService;
        }

        public bool editarProducto(ProductoInventarioEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.PRODUCTOS.Where(x => x.ID_PRODUCTO == objeto.ID_PRODUCTO).FirstOrDefault();
            try
            {
                if (elemento != null)
                {
                    _repositorio.Entry(elemento).CurrentValues.SetValues(objeto);
                    _repositorio.SaveChanges();
                    crearInventario(objeto);
                    retorno = true;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }
            return retorno;

            return retorno;
        }

        public bool eliminarProducto(ProductoEntity objeto)
        {
            var retorno = false;
            var result = _repositorio.PRODUCTOS.SingleOrDefault(b => b.ID_PRODUCTO == objeto.ID_PRODUCTO);
            var estado = _repositorio.ESTADO.SingleOrDefault(e => e.DESCRIPCION_ESTADO.ToLower().Contains("anulado"));
            if (result != null)
            {

                if (result != null)
                {
                    try
                    {
                        var editado = new PRODUCTOS
                        {
                            ID_ESTADO = estado.ID_ESTADO
                        };
                        _repositorio.PRODUCTOS.Attach(editado);
                        _repositorio.Entry(editado).State = System.Data.EntityState.Deleted;
                        _repositorio.SaveChanges();
                        _detalleFacturasService.actualizarStock(objeto.ID_PRODUCTO, 0);
                        retorno = true;
                    }

                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo modificar el elemento!", ex);
                    }
                }
            }

            return retorno;
        }

        public bool ingresarProducto(ProductoInventarioEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.PRODUCTOS.Where(x => x.DESCRIPCION_PRODUCTO.Contains(objeto.DESCRIPCION_PRODUCTO)).FirstOrDefault();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.Contains("ingreso")).FirstOrDefault();
            var bscInventario = _repositorio.INVENTARIO.Where(x => x.ID_PRODUCTO == objeto.ID_PRODUCTO).FirstOrDefault();
            if (elemento == null)
            {
                try
                {
                    var item = new PRODUCTOS();
                    item.DESCRIPCION_PRODUCTO = objeto.DESCRIPCION_PRODUCTO;
                    item.ID_ESTADO = estado.ID_ESTADO;
                    item.ID_UNIDAD = _repositorio.UNIDADES.Where(x => x.ID_UNIDAD == objeto.ID_UNIDAD).Select(u => u.ID_UNIDAD).FirstOrDefault();
                    _repositorio.PRODUCTOS.Add(item);
                    _repositorio.SaveChanges();
                    objeto.ID_PRODUCTO= item.ID_PRODUCTO;
                    crearInventario(objeto);
                    retorno = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo ingresar el elemento!", ex);
                }
            }
            else
            {
                retorno = editarProducto(objeto);
            }
            return retorno;
        }

        public bool crearInventario(ProductoInventarioEntity objeto)
        {
            var retorno = false;
            try
            {
                var ultimoInv = _repositorio.INVENTARIO.Where(x => x.ID_PRODUCTO == objeto.ID_PRODUCTO).OrderByDescending(x => x.ID_INVENTARIO).FirstOrDefault();
                if (ultimoInv == null)
                {
                    var item = new INVENTARIO();
                    item.ID_PRODUCTO = objeto.ID_PRODUCTO;
                    item.ID_ESTADO = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.Contains("ingreso")).FirstOrDefault().ID_ESTADO;
                    //Valida y actualiza el Stock si ingresa o sale productos
                    item.STOCK_INVENTARIO = objeto.CANTIDAD_INGRESO != null ? objeto.CANTIDAD_INGRESO : 0;

                    if (objeto.CANTIDAD_INGRESO != null)
                        item.FECHA_INGRESO = DateTime.Now;
                    if (objeto.CANTIDAD_SALIDA != null)
                        item.FECHA_SALIDA = DateTime.Now;

                    item.CANTIDAD_INGRESO = objeto.CANTIDAD_INGRESO != null ? objeto.CANTIDAD_INGRESO : 0;
                    item.CANTIDAD_SALIDA = objeto.CANTIDAD_SALIDA != null ? objeto.CANTIDAD_SALIDA : 0;

                    item.PRECIO_UNITARIO = objeto.Precio;
                    _repositorio.INVENTARIO.Add(item);
                    _repositorio.SaveChanges();

                    retorno = true;
                }
                else
                {
                    var item = new INVENTARIO();
                    item.ID_PRODUCTO = objeto.ID_PRODUCTO;
                    item.ID_ESTADO = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.Contains("ingreso")).FirstOrDefault().ID_ESTADO;
                    //Valida y actualiza el Stock si ingresa o sale productos
                    item.STOCK_INVENTARIO =   objeto.CANTIDAD_INGRESO;

                    if (objeto.CANTIDAD_INGRESO != null)
                        item.FECHA_INGRESO = DateTime.Now;
                    if (objeto.CANTIDAD_SALIDA != null)
                        item.FECHA_SALIDA = DateTime.Now;

                    item.CANTIDAD_INGRESO = objeto.CANTIDAD_INGRESO != null && ultimoInv.STOCK_INVENTARIO != objeto.CANTIDAD_INGRESO ? objeto.CANTIDAD_INGRESO + ultimoInv.STOCK_INVENTARIO : objeto.CANTIDAD_INGRESO;
                    item.CANTIDAD_SALIDA = objeto.CANTIDAD_SALIDA != null ? objeto.CANTIDAD_SALIDA : 0;

                    item.PRECIO_UNITARIO = objeto.Precio;
                    _repositorio.INVENTARIO.Add(item);
                    _repositorio.SaveChanges();

                    retorno = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
            }
            return retorno;
        }

        public List<ProductoInventarioEntity> listaProductos()
        {
            var lista = _repositorio.INVENTARIO.ToList();
            var retorno = new List<ProductoInventarioEntity>();
            lista.ForEach(g =>
            {
                var item = new ProductoInventarioEntity();
                item.ID_PRODUCTO = g.ID_PRODUCTO.Value;
                item.DESCRIPCION_PRODUCTO = g.PRODUCTOS.DESCRIPCION_PRODUCTO;
                item.STOCK_INVENTARIO = g.STOCK_INVENTARIO;
                item.Precio = g.PRECIO_UNITARIO;
                item.CANTIDAD_INGRESO = g.CANTIDAD_INGRESO;
                item.FECHA_INGRESO = g.FECHA_INGRESO;
                item.CANTIDAD_SALIDA = g.CANTIDAD_SALIDA;
                item.FECHA_SALIDA = g.FECHA_SALIDA;
                retorno.Add(item);
            });
            return retorno;
        }

        public List<ListaProductos> obtenerProducto(int codigo)
        {
            var lista = _repositorio.INVENTARIO.Where(x => x.ID_PRODUCTO == codigo)
            .GroupBy(x => new
            {
                x.ID_PRODUCTO,
                x.PRODUCTOS.DESCRIPCION_PRODUCTO,
                x.STOCK_INVENTARIO,
                x.PRECIO_UNITARIO,
            })
                .Select(g => new ListaProductos()
                {
                    ID_PRODUCTO = g.Key.ID_PRODUCTO.Value,
                    DESCRIPCION_PRODUCTO = g.Key.DESCRIPCION_PRODUCTO,
                    STOCK = g.Key.STOCK_INVENTARIO,
                    PRECIO_UNITARIO = g.Key.PRECIO_UNITARIO,
                }).ToList();
            return lista;
        }
    }
}
