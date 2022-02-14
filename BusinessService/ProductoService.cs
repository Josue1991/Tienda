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
        public ProductoService()
        {
            _repositorio = new base1Entities();
        }

        public bool editarProducto(ProductoEntity objeto)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.PRODUCTOS.SingleOrDefault(b => b.ID_PRODUCTO == objeto.ID_PRODUCTO);
                var editado = new PRODUCTOS
                {
                    DESCRIPCION_PRODUCTO = objeto.DESCRIPCION_PRODUCTO,
                    CANTIDAD_PRODUCTO = objeto.CANTIDAD_PRODUCTO,
                    PRECIO_UNITARIO = objeto.PRECIO_UNITARIO,
                    ESTADO_PRODUCTO = objeto.ESTADO_PRODUCTO
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
                                ESTADO_PRODUCTO = estado.ID_ESTADO
                            };
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
            }
            return retorno;
        }

        public bool ingresarProducto(ProductoEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.PRODUCTOS.Where(x => x.DESCRIPCION_PRODUCTO.ToLower().Contains(objeto.DESCRIPCION_PRODUCTO.ToLower())).FirstOrDefault();

            if (elemento == null)
            {
                using (var context = new base1Entities())
                {
                    try
                    {
                        var item = new PRODUCTOS();
                        item.DESCRIPCION_PRODUCTO = objeto.DESCRIPCION_PRODUCTO;
                        item.CANTIDAD_PRODUCTO = objeto.CANTIDAD_PRODUCTO;
                        item.PRECIO_UNITARIO = objeto.PRECIO_UNITARIO;
                        item.ESTADO_PRODUCTO = objeto.ESTADO_PRODUCTO;
                        context.PRODUCTOS.Add(item);
                        context.SaveChanges();
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

        public List<ProductoEntity> listaProductos()
        {
            List<ProductoEntity> retorno = new List<ProductoEntity>();
            var lista = _repositorio.PRODUCTOS.ToList();

            lista.ForEach(x =>
            {
                var item = new ProductoEntity();
                item.ID_PRODUCTO = x.ID_PRODUCTO;
                item.DESCRIPCION_PRODUCTO = x.DESCRIPCION_PRODUCTO;
                item.CANTIDAD_PRODUCTO = x.CANTIDAD_PRODUCTO;
                item.PRECIO_UNITARIO = x.PRECIO_UNITARIO;
                item.ESTADO_PRODUCTO=x.ESTADO_PRODUCTO.Value;
                retorno.Add(item);
            });
            return retorno;
        }

        public ProductoEntity obtenerProducto(int codigo)
        {
            ProductoEntity retorno = new ProductoEntity();
            var lista = _repositorio.PRODUCTOS.Where(x => x.ID_PRODUCTO == codigo).ToList();

            lista.ForEach(x =>
            {
                var item = new ProductoEntity();
                item.ID_PRODUCTO = x.ID_PRODUCTO;
                item.DESCRIPCION_PRODUCTO = x.DESCRIPCION_PRODUCTO;
                item.CANTIDAD_PRODUCTO=x.CANTIDAD_PRODUCTO;
                item.PRECIO_UNITARIO=x.PRECIO_UNITARIO;
                item.ESTADO_PRODUCTO= x.ESTADO_PRODUCTO.Value;
                retorno = item;
            });
            return retorno;
        }
    }
}
