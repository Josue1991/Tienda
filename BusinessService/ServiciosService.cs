using BusinessEntity;
using BusinessService1.impl;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessService1
{
    public class ServiciosService : IServiciosService
    {
        base1Entities _repositorio;
        public ServiciosService(base1Entities repositorio)
        {
            _repositorio = repositorio;
        }

        public bool crearServicios(ServiciosEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.SERVICIO.Where(x => x.DESCRIPCION_SERVICIO.Contains(objeto.DESCRIPCION_SERVICIO)).FirstOrDefault();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.Contains("activo"));

            try
            {
                if (elemento == null)
                {
                    var item = new SERVICIO();
                    item.DESCRIPCION_SERVICIO = objeto.DESCRIPCION_SERVICIO;
                    item.PRECIO_SERVICIO = objeto.PRECIO_SERVICIO;
                    _repositorio.SERVICIO.Add(item);
                    _repositorio.SaveChanges();
                    crearDetallesServicios(objeto.DETALLESERVICIO);
                    retorno = true;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
            }
            return retorno;
        }

        public bool crearDetallesServicios(List<DetalleServicioEntity> objeto)
        {
            var retorno = false;
            var lista = new List<DETALLESERVICIO>();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.Contains("activo"));
            try
            {
                objeto.ForEach(x =>
                {
                    var item = new DETALLESERVICIO();
                    item.ID_SERVICIO = x.ID_SERVICIO;
                    item.ID_PRODUCTO = x.ID_PRODUCTO;
                    lista.Add(item);
                });
                lista.ForEach(e =>
                {
                    _repositorio.DETALLESERVICIO.Add(e);
                });
                _repositorio.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
            }
            return retorno;
        }

        public bool editarServicio(ServiciosEntity objeto)
        {
            var retorno = false;
            var elemento = _repositorio.SERVICIO.Where(x => x.DESCRIPCION_SERVICIO.Contains(objeto.DESCRIPCION_SERVICIO)).FirstOrDefault();
            try
            {
                if (elemento != null)
                {
                    _repositorio.Entry(elemento).CurrentValues.SetValues(objeto);
                    _repositorio.SaveChanges();
                    retorno = true;
                    editarDetalleServicio(objeto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }

            return retorno;
        }

        public bool editarDetalleServicio(ServiciosEntity objeto)
        {
            var retorno = false;
            var elementos = _repositorio.DETALLESERVICIO.Where(x => x.ID_SERVICIO == objeto.ID_SERVICIO).ToList();
            try
            {
                if (elementos != null)
                {
                    elementos.ForEach(x =>
                    {
                        _repositorio.Entry(x).CurrentValues.SetValues(objeto);
                        _repositorio.SaveChanges();
                    });
                    retorno = true;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }
            return retorno;
        }

        public List<ServiciosEntity> listarServicios()
        {
            return _repositorio.SERVICIO.Select(x => new ServiciosEntity
            {
                ID_SERVICIO = x.ID_SERVICIO,
                DESCRIPCION_SERVICIO = x.DESCRIPCION_SERVICIO,
                PRECIO_SERVICIO = x.PRECIO_SERVICIO
            }).ToList();
        }

        public ServiciosEntity obtenerServicios(ServiciosEntity objeto)
        {
            return _repositorio.SERVICIO
                .Where(x => x.DESCRIPCION_SERVICIO.Contains(objeto.DESCRIPCION_SERVICIO))
                .Select(x => new ServiciosEntity
                {
                    ID_SERVICIO = x.ID_SERVICIO,
                    DESCRIPCION_SERVICIO = x.DESCRIPCION_SERVICIO,
                    PRECIO_SERVICIO = x.PRECIO_SERVICIO
                }).FirstOrDefault();
        }
    }
}
