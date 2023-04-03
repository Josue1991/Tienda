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
    public class FormaPagoService : IFormaPagoService
    {
        base1Entities _repositorio;
        public FormaPagoService(base1Entities repositorio)
        {
            _repositorio = repositorio;
        }

        public bool editarFormaPago(FormaPagoEntity objeto)
        {
            var retorno = false;

            var result = _repositorio.FORMAPAGO.Where(b => b.ID_FORMAPAGO == objeto.ID_FORMAPAGO).FirstOrDefault();
            if (result != null)
            {
                try
                {
                    result.DESCRIPCION_FORMA = objeto.DESCRIPCION_FORMA;
                    _repositorio.SaveChanges();
                    retorno = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo modificar el elemento!", ex);
                }
            }
            return retorno;
        }

        public bool eliminarFormaPago(FormaPagoEntity objeto)
        {
            var retorno = false;
            var result = _repositorio.FORMAPAGO.SingleOrDefault(b => b.ID_FORMAPAGO == objeto.ID_FORMAPAGO);
            if (result != null)
            {
                try
                {
                    _repositorio.Entry(result).State = System.Data.EntityState.Deleted;
                    _repositorio.SaveChanges();
                    retorno = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo modificar el elemento!", ex);
                }
            }
            return retorno;
        }

        public bool ingresarFormaPago(FormaPagoEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.FORMAPAGO.Where(x => x.DESCRIPCION_FORMA.ToLower().Contains(objeto.DESCRIPCION_FORMA.ToLower())).FirstOrDefault();

            if (elemento == null)
            {
                using (var context = new base1Entities())
                {
                    try
                    {
                        var item = new FORMAPAGO();
                        item.DESCRIPCION_FORMA = objeto.DESCRIPCION_FORMA;
                        item.ESTADO_FORMAPAGO = objeto.ESTADO_FORMAPAGO;
                        context.FORMAPAGO.Add(item);
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

        public List<FormaPagoEntity> ListaFormaPago()
        {
            List<FormaPagoEntity> retorno = new List<FormaPagoEntity>();
            var lista = _repositorio.FORMAPAGO.ToList();

            lista.ForEach(x =>
            {
                var estados = _repositorio.ESTADO.Where(e => e.ID_ESTADO == x.ESTADO_FORMAPAGO).FirstOrDefault();
                var estadoCli = new EstadoEntity();
                estadoCli.ID_ESTADO = estados.ID_ESTADO;
                estadoCli.DESCRIPCION_ESTADO = estados.DESCRIPCION_ESTADO;
                var item = new FormaPagoEntity();
                item.ID_FORMAPAGO = x.ID_FORMAPAGO;
                item.DESCRIPCION_FORMA = x.DESCRIPCION_FORMA;
                retorno.Add(item);
            });
            return retorno;
        }

        public FormaPagoEntity obtenerFormaPago(int codigo)
        {
            FormaPagoEntity retorno = new FormaPagoEntity();
            var lista = _repositorio.FORMAPAGO.Where(x => x.ID_FORMAPAGO == codigo).ToList();

            lista.ForEach(x =>
            {
                var estados = _repositorio.ESTADO.Where(e => e.ID_ESTADO == x.ESTADO_FORMAPAGO).FirstOrDefault();
                var estadoCli = new EstadoEntity();
                estadoCli.ID_ESTADO = estados.ID_ESTADO;
                estadoCli.DESCRIPCION_ESTADO = estados.DESCRIPCION_ESTADO;
                var item = new FormaPagoEntity();
                item.ID_FORMAPAGO = x.ID_FORMAPAGO;
                item.DESCRIPCION_FORMA = x.DESCRIPCION_FORMA;
                retorno = item;
            });
            return retorno;
        }
    }
}
