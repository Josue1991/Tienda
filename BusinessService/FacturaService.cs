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
    public class FacturaService : IFacturaService
    {
        base1Entities _repositorio;
        public FacturaService()
        {
            _repositorio = new base1Entities();
        }

        public bool anularFactura(ClientesEntity objeto, int numeroFactura)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.FACTURA.SingleOrDefault(b => b.COD_FACTURA == numeroFactura && b.CLIENTE.CEDULA == objeto.CEDULA);
                var estado = db.ESTADO.SingleOrDefault(e => e.DESCRIPCION_ESTADO.ToLower().Contains("anulado"));
                if (result != null)
                {
                    try
                    {
                        result.ESTADO_FACTURA = estado.ID_ESTADO;
                        db.SaveChanges();
                        retorno = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo anular el elemento!", ex);
                    }
                }
            }
            return retorno;
        }
        public bool crearDetalles(FacturasEntity faturas)
        {
            var retorno = false;
            var detalles = new DETALLE_FACTURA();
            var cantidad = 0;
            decimal precioTotal = 0;
            var listaDetalles = new List<DETALLE_FACTURA>();
            using (var context = new base1Entities())
            {
                try
                {
                    var estado = context.ESTADO.SingleOrDefault(e => e.DESCRIPCION_ESTADO.ToLower().Contains("activo"));
                    var item = context.FACTURA.SingleOrDefault(e => e.COD_FACTURA == faturas.COD_FACTURA);
                    faturas.DETALLE_FACTURA.ToList().ForEach(e =>
                    {
                        var producto = context.PRODUCTOS.SingleOrDefault(p => p.ID_PRODUCTO == e.ID_PRODUCTO.Value);
                        detalles.COD_FACTURA = faturas.COD_FACTURA;
                        detalles.CANTIDAD_DETALLE = e.CANTIDAD_DETALLE;
                        detalles.ESTADO_DETALLE = estado.ID_ESTADO;
                        detalles.PRECIO_PRODUCTO = e.PRECIO_PRODUCTO;
                        detalles.ID_PRODUCTO = e.ID_PRODUCTO;
                        detalles.PRECIO_TOTAL = producto.PRECIO_UNITARIO * e.CANTIDAD_DETALLE;
                        precioTotal = precioTotal + detalles.PRECIO_TOTAL.Value;
                        cantidad = e.CANTIDAD_DETALLE.Value;
                        if (actualizarStock(producto.ID_PRODUCTO, cantidad))
                        {
                            listaDetalles.Add(detalles);
                        }
                    });

                    listaDetalles.ForEach(e =>
                    {
                        context.DETALLE_FACTURA.Add(e);                        
                    });
                    context.SaveChanges();

                    //Suma Total
                    decimal sub_total = precioTotal;
                    decimal sub_iva = (precioTotal * 12) / 100;
                    decimal total = sub_total + sub_iva;
                    actualizarValoresFactura(sub_total, sub_iva, total,faturas.COD_FACTURA);

                    retorno = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo ingresar el elemento!", ex);
                }
            }
            return retorno;
        }


        public bool crearFactura(FacturasEntity faturas)
        {
            var retorno = false;
            using (var context = new base1Entities())
            {
                try
                {
                    var item = new FACTURA();
                    var detalles = new DETALLE_FACTURA();

                    decimal precioTotal = 0;
                    //Ingreso Encabezado
                    item.ID_CLIENTE = faturas.ID_CLIENTE;
                    item.COD_FACTURA = faturas.COD_FACTURA;
                    item.ESTADO_FACTURA = faturas.ESTADO_FACTURA;
                    item.FECHA_FACTURA = faturas.FECHA_FACTURA;
                    context.FACTURA.Add(item);
                    context.SaveChanges();
                    crearDetalles(faturas);

                    retorno = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo ingresar el elemento!", ex);
                }
            }
            return retorno;
        }

        public bool actualizarStock(int cod_producto, int cantidad)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.PRODUCTOS.SingleOrDefault(b => b.ID_PRODUCTO == cod_producto);
                if (result != null)
                {
                    try
                    {
                        result.CANTIDAD_PRODUCTO = result.CANTIDAD_PRODUCTO - cantidad;
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
        public bool actualizarValoresFactura(decimal precio, decimal precioIva, decimal preciototal,int codigo)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.FACTURA.SingleOrDefault(b => b.COD_FACTURA == codigo);
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

        public bool editarFactura(ClientesEntity cliente)
        {
            throw new NotImplementedException();
        }

        public List<FacturasEntity> ListaFacturaClientes(ClientesEntity objeto)
        {
            throw new NotImplementedException();
        }
    }
}
