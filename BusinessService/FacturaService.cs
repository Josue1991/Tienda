using BusinessEntity;
using BusinessService1.impl;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1
{
    public class FacturaService : IFacturaService
    {
        base1Entities _repositorio;
        DetalleFacturaService _detalleFactura;
        public FacturaService(base1Entities repositorio, DetalleFacturaService detalleFactura)
        {
            _repositorio = repositorio;
            _detalleFactura = detalleFactura;
        }

        public bool anularFactura(ClientesEntity objeto, int numeroFactura)
        {
            var retorno = false;
            var result = _repositorio.FACTURA.SingleOrDefault(b => b.ID_FACTURA == numeroFactura && b.CLIENTE.CEDULA == objeto.CEDULA);
            var estado = _repositorio.ESTADO.Where(e => e.DESCRIPCION_ESTADO.ToLower().Contains("anulado")).FirstOrDefault();
            if (result != null)
            {
                try
                {
                    result.ESTADO_FACTURA = estado.ID_ESTADO;
                    _repositorio.SaveChanges();
                    retorno = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo anular el elemento!", ex);
                }
            }

            return retorno;
        }

        public bool crearFactura(FacturasEntity faturas)
        {
            var retorno = false;

            try
            {
                var item = new FACTURA();
                var detalles = new DETALLE_FACTURA();

                decimal precioTotal = 0;
                //Ingreso Encabezado
                item.ID_CLIENTE = faturas.ID_CLIENTE;
                item.ID_FACTURA = faturas.COD_FACTURA;
                item.ESTADO_FACTURA = faturas.ESTADO_FACTURA;
                item.FECHA_FACTURA = faturas.FECHA_FACTURA;
                _repositorio.FACTURA.Add(item);
                _repositorio.SaveChanges();
                _detalleFactura.crearDetalles(faturas);

                retorno = true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
            }

            return retorno;
        }
        //Cuando se vende el producto


        //Cuando se compra mas cantidad del producto
        public bool comprarStock(int cod_producto, decimal cantidad)
        {
            var retorno = false;

            try
            {
                var ultimoInv = _repositorio.INVENTARIO.Where(x => x.ID_PRODUCTO == cod_producto)
                    .OrderByDescending(x => x.ID_INVENTARIO).FirstOrDefault();
                var estado = _repositorio.ESTADO.Where(e => e.DESCRIPCION_ESTADO.Contains("Ingreso")).FirstOrDefault();
                var item = new INVENTARIO();

                //Ingreso Encabezado
                item.ID_PRODUCTO = cod_producto;
                item.ID_ESTADO = estado.ID_ESTADO;
                item.STOCK_INVENTARIO = ultimoInv.STOCK_INVENTARIO + cantidad;
                item.FECHA_INGRESO = DateTime.Now;
                item.CANTIDAD_INGRESO = cantidad;
                item.PRECIO_UNITARIO = ultimoInv.PRECIO_UNITARIO;
                _repositorio.INVENTARIO.Add(item);
                _repositorio.SaveChanges();
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
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
