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
    public class DetalleFacturaService : IDetalleFacturaService
    {
        base1Entities _context;
        public DetalleFacturaService(base1Entities context)
        {
            _context = context;
        }
        public bool crearDetalles(FacturasEntity faturas)
        {
            var retorno = false;
            var detalles = new DETALLE_FACTURA();
            var cantidad = 0;
            decimal precioTotal = 0;
            var listaDetalles = new List<DETALLE_FACTURA>();

            try
            {
                var estado = _context.ESTADO.SingleOrDefault(e => e.DESCRIPCION_ESTADO.ToLower().Contains("activo"));
                var item = _context.FACTURA.SingleOrDefault(e => e.ID_FACTURA == faturas.COD_FACTURA);
                faturas.DETALLE_FACTURA.ToList().ForEach(e =>
                {
                    var producto = _context.PRODUCTOS.SingleOrDefault(p => p.ID_PRODUCTO == e.ID_PRODUCTO.Value);
                    var inventario = _context.INVENTARIO.Where(i => i.PRODUCTOS.ID_PRODUCTO == e.ID_PRODUCTO)
                    .OrderByDescending(x => x.FECHA_SALIDA).FirstOrDefault();

                    detalles.ID_DETALLE = faturas.COD_FACTURA;
                    detalles.CANTIDAD_DETALLE = e.CANTIDAD_DETALLE;
                    detalles.ID_ESTADO = estado.ID_ESTADO;
                    detalles.PRECIO_PRODUCTO = e.PRECIO_PRODUCTO;
                    detalles.ID_PRODUCTO = e.ID_PRODUCTO;
                    detalles.PRECIO_TOTAL = inventario.PRECIO_UNITARIO * e.CANTIDAD_DETALLE;
                    precioTotal = precioTotal + detalles.PRECIO_TOTAL.Value;
                    cantidad = e.CANTIDAD_DETALLE.Value;
                    if (actualizarStock(producto.ID_PRODUCTO, cantidad))
                    {
                        listaDetalles.Add(detalles);
                    }
                });

                listaDetalles.ForEach(e =>
                {
                    _context.DETALLE_FACTURA.Add(e);
                });
                _context.SaveChanges();

                //Suma Total
                decimal sub_total = precioTotal;
                decimal sub_iva = (precioTotal * 12) / 100;
                decimal total = sub_total + sub_iva;
                actualizarValoresFactura(sub_total, sub_iva, total, faturas.COD_FACTURA);

                retorno = true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
            }

            return retorno;
        }
        public bool actualizarStock(int cod_producto, decimal cantidad)
        {
            var retorno = false;

            try
            {
                var ultimoInv = _context.INVENTARIO.Where(x => x.ID_PRODUCTO == cod_producto)
                    .OrderByDescending(x => x.ID_INVENTARIO).FirstOrDefault();
                var estado = _context.ESTADO.Where(e => e.DESCRIPCION_ESTADO.Contains("Salida")).FirstOrDefault();
                var eliminado = _context.ESTADO.Where(e => e.DESCRIPCION_ESTADO.Contains("Eliminado")).FirstOrDefault();
                var item = new INVENTARIO();

                //Ingreso Encabezado
                item.ID_PRODUCTO = cod_producto;
                item.ID_ESTADO = estado.ID_ESTADO;
                if (cantidad == 0)
                {
                    item.CANTIDAD_SALIDA = ultimoInv.STOCK_INVENTARIO;
                    item.ID_ESTADO = eliminado.ID_ESTADO;
                    item.CANTIDAD_INGRESO = 0;
                    item.STOCK_INVENTARIO = 0;
                }
                else
                {
                    item.CANTIDAD_SALIDA = cantidad;
                    item.ID_ESTADO = estado.ID_ESTADO;
                    item.CANTIDAD_INGRESO = 0;
                    item.STOCK_INVENTARIO = ultimoInv.STOCK_INVENTARIO - cantidad;
                }
                item.FECHA_SALIDA = DateTime.Now;
                item.PRECIO_UNITARIO = ultimoInv.PRECIO_UNITARIO;
                _context.INVENTARIO.Add(item);
                _context.SaveChanges();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
            }
            return retorno;

        }

        public bool actualizarValoresFactura(decimal precio, decimal precioIva, decimal preciototal, int codigo)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.FACTURA.SingleOrDefault(b => b.ID_FACTURA == codigo);
                if (result != null)
                {
                    try
                    {
                        result.SUB_TOTAL = precio;
                        result.SUB_TOTAL_IVA = precioIva;
                        result.TOTAL = preciototal;
                        db.SaveChanges();
                        retorno = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo actualizar el stock el elemento!", ex);
                    }
                }
            }
            return retorno;
        }

    }
}
