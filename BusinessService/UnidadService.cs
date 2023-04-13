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
    public class UnidadService : IUnidadService
    {
        base1Entities _repositorio;
        public UnidadService(base1Entities repositorio)
        {
            _repositorio = repositorio;
        }

        public bool crearUnidad(UnidadesEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.UNIDADES.Where(x => x.DESCRIPCION_UNIDAD.Contains(objeto.DESCRIPCION_UNIDAD)).FirstOrDefault();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.Contains("activo"));

            try
            {
                if (elemento == null)
                {
                    var item = new UNIDADES();
                    item.DESCRIPCION_UNIDAD = objeto.DESCRIPCION_UNIDAD;
                    item.ABREVIATURA_UNIDAD = objeto.ABREVIATURA_UNIDAD;
                    item.EQUIVALENCIA_UNIDAD = objeto.EQUIVALENCIA_UNIDAD;
                    _repositorio.UNIDADES.Add(item);
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

        public bool editarUnidad(UnidadesEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.UNIDADES.Where(x => x.ID_UNIDAD == objeto.ID_UNIDAD).FirstOrDefault();
            try
            {
                if (elemento != null)
                {
                        _repositorio.Entry(elemento).CurrentValues.SetValues(objeto);
                        _repositorio.SaveChanges();
                        retorno = true;
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }
            return retorno;
        }

        public List<UnidadesEntity> listarUnidades()
        {
            var retorno = new List<UnidadesEntity>();
            retorno = _repositorio.UNIDADES.Select(x => new UnidadesEntity
            {
                ID_UNIDAD = x.ID_UNIDAD,
                DESCRIPCION_UNIDAD = x.DESCRIPCION_UNIDAD,
                ABREVIATURA_UNIDAD = x.ABREVIATURA_UNIDAD,
                EQUIVALENCIA_UNIDAD = x.EQUIVALENCIA_UNIDAD
            }).ToList();
            return retorno;
        }
        public UnidadesEntity obtenerUnidades(int codigo)
        {
            var retorno = new UnidadesEntity();
            retorno = _repositorio.UNIDADES.Where(x => x.ID_UNIDAD == codigo).Select(x => new UnidadesEntity
            {
                ID_UNIDAD = x.ID_UNIDAD,
                DESCRIPCION_UNIDAD = x.DESCRIPCION_UNIDAD,
                ABREVIATURA_UNIDAD = x.ABREVIATURA_UNIDAD,
                EQUIVALENCIA_UNIDAD = x.EQUIVALENCIA_UNIDAD
            }).FirstOrDefault();
            return retorno;
        }
    }
}
