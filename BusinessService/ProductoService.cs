using BusinessEntity;
using BusinessService1.impl;
using DataModel;
using System;
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
        public ProductoService(FacturaService facturaService)
        {
            _facturaService = facturaService;
            _repositorio = new base1Entities();
        }

        public bool editarProducto(ProductoEntity objeto)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.PRODUCTOS.SingleOrDefault(b => b.ID_PRODUCTO == objeto.ID_PRODUCTO);
                var inventario = db.INVENTARIO.Where(i => i.ID_PRODUCTO == result.ID_PRODUCTO);
                var editado = new PRODUCTOS
                {
                    DESCRIPCION_PRODUCTO = objeto.DESCRIPCION_PRODUCTO,
                    ID_ESTADO = objeto.ID_ESTADO,
                    ID_UNIDAD = objeto.ID_UNIDAD
                };
                if (result != null)
                {
                    try
                    {
                        db.PRODUCTOS.Attach(editado);
                        db.Entry(editado).State = System.Data.EntityState.Deleted;
                        db.SaveChanges();
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

        public bool eliminarProducto(ProductoEntity objeto)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.PRODUCTOS.SingleOrDefault(b => b.ID_PRODUCTO == objeto.ID_PRODUCTO);
                var estado = db.ESTADO.SingleOrDefault(e => e.DESCRIPCION_ESTADO.ToLower().Contains("anulado"));
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
                            db.PRODUCTOS.Attach(editado);
                            db.Entry(editado).State = System.Data.EntityState.Deleted;
                            db.SaveChanges();
                            _facturaService.actualizarStock(objeto.ID_PRODUCTO, 0);
                            retorno = true;
                        }

                        catch (Exception ex)
                        {
                            throw new Exception("No se pudo modificar el elemento!", ex);
                        }
                    }
                }
            }
            return retorno;
        }

        public bool ingresarProducto(ProductoEntity objeto, InventarioEntity inventario)
        {
            var retorno = false;
            var elemento = _repositorio.PRODUCTOS.Where(x => x.DESCRIPCION_PRODUCTO.ToLower().Contains(objeto.DESCRIPCION_PRODUCTO.ToLower())).FirstOrDefault();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.ToLower().Contains("ingreso")).FirstOrDefault();
            var bscInventario = _repositorio.INVENTARIO.Where(x => x.ID_PRODUCTO == objeto.ID_PRODUCTO).FirstOrDefault();
            if (elemento == null)
            {
                using (var context = new base1Entities())
                {
                    try
                    {
                        var item = new PRODUCTOS();
                        item.DESCRIPCION_PRODUCTO = objeto.DESCRIPCION_PRODUCTO;
                        item.ID_ESTADO = estado.ID_ESTADO;
                        item.ID_UNIDAD = _repositorio.UNIDADES.Where(x => x.ID_UNIDAD == objeto.ID_UNIDAD).Select(u => u.ID_UNIDAD).FirstOrDefault();
                        context.PRODUCTOS.Add(item);
                        context.SaveChanges();
                        if (bscInventario != null)
                        {
                            _facturaService.actualizarStock(objeto.ID_PRODUCTO, inventario.CANTIDAD_INGRESO.Value);
                        }
                        else
                        {
                            _facturaService.comprarStock(objeto.ID_PRODUCTO, inventario.CANTIDAD_INGRESO.Value);
                        }
                        retorno = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo ingresar el elemento!", ex);
                    }
                }
            }
            return retorno;
        }

        public List<ListaProductos> listaProductos()
        {
            var lista = _repositorio.INVENTARIO
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
