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
    public class EstadoService : IEstadoService
    {
        base1Entities _repositorio;
        public EstadoService(base1Entities repositorio)
        {
            _repositorio = repositorio;
        }

        public bool editarEstado(EstadoEntity objeto)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.ESTADO.SingleOrDefault(b => b.ID_ESTADO == objeto.ID_ESTADO);
                if (result != null)
                {
                    try
                    {
                        result.DESCRIPCION_ESTADO = objeto.DESCRIPCION_ESTADO;
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

        public bool eliminarEstado(EstadoEntity objeto)
        {
            var retorno = false;
            using (var db = new base1Entities())
            {
                var result = db.ESTADO.SingleOrDefault(b => b.ID_ESTADO == objeto.ID_ESTADO);
                if (result != null)
                {
                    try
                    {
                        db.Entry(result).State = System.Data.EntityState.Deleted;
                        db.SaveChanges();
                        retorno = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se pudo eliminar el elemento!", ex);
                    }
                }
            }
            return retorno;
        }

        public bool ingresarEstado(EstadoEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.ToLower().Contains(objeto.DESCRIPCION_ESTADO.ToLower())).FirstOrDefault();

            if (elemento == null)
            {
                using (var context = new base1Entities())
                {
                    try
                    {
                        var item = new ESTADO();
                        item.DESCRIPCION_ESTADO = objeto.DESCRIPCION_ESTADO;
                        context.ESTADO.Add(item);
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

        public List<EstadoEntity> listaEstado()
        {
            List<EstadoEntity> retorno = new List<EstadoEntity>();
            var lista = _repositorio.ESTADO.ToList();

            lista.ForEach(x =>
            {
                var estados = _repositorio.ESTADO.Where(e => e.ID_ESTADO == x.ID_ESTADO).FirstOrDefault();
                var estadoCli = new EstadoEntity();
                estadoCli.ID_ESTADO = estados.ID_ESTADO;
                estadoCli.DESCRIPCION_ESTADO = estados.DESCRIPCION_ESTADO;
                var item = new EstadoEntity();
                item.ID_ESTADO = x.ID_ESTADO;
                item.DESCRIPCION_ESTADO = x.DESCRIPCION_ESTADO;
                retorno.Add(item);
            });
            return retorno;
        }

        public EstadoEntity obtenerEstado(int codigo)
        {
            EstadoEntity retorno = new EstadoEntity();
            var lista = _repositorio.ESTADO.Where(x => x.ID_ESTADO == codigo).ToList();

            lista.ForEach(x =>
            {
                var estados = _repositorio.ESTADO.Where(e => e.ID_ESTADO == x.ID_ESTADO).FirstOrDefault();
                var estadoCli = new EstadoEntity();
                estadoCli.ID_ESTADO = estados.ID_ESTADO;
                estadoCli.DESCRIPCION_ESTADO = estados.DESCRIPCION_ESTADO;
                var item = new EstadoEntity();
                item.ID_ESTADO = x.ID_ESTADO;
                item.DESCRIPCION_ESTADO = x.DESCRIPCION_ESTADO;
                retorno = item;
            });
            return retorno;
        }
    }
}
