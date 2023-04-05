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
    public class EmpleadoService : IEmpleadoService
    {
        base1Entities _repositorio;
        UsuarioService _usuarioService;
        public EmpleadoService(base1Entities repositorio, UsuarioService usuarioService)
        {
            _repositorio = repositorio;
            _usuarioService = usuarioService;
        }

        public bool BorrarEmpleado(EmpleadoEntity empleado)
        {
            var retorno = false;
            var elemento = _repositorio.EMPLEADO.Where(x => x.DNI_EMPLEADO == empleado.DNI_EMPLEADO).FirstOrDefault();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.ToLower().Contains("inactivo")).FirstOrDefault();
            try
            {
                if (elemento != null)
                {
                    empleado.ID_EMPLEADO = estado.ID_ESTADO;
                    _repositorio.Entry(elemento).CurrentValues.SetValues(empleado);
                    _repositorio.SaveChanges();
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el elemento!", ex);
            }
            return retorno;
        }

        public bool CrearEmpleado(EmpleadoEntity empleado)
        {
            var retorno = false;
            var elemento = _repositorio.EMPLEADO.Where(x => x.DNI_EMPLEADO == empleado.DNI_EMPLEADO).FirstOrDefault();
            try
            {
                if (elemento == null)
                {
                    var item = new EMPLEADO();
                    item.DNI_EMPLEADO = empleado.DNI_EMPLEADO;
                    item.NOMBRE_EMPLEADO = empleado.NOMBRE_EMPLEADO;
                    item.APELLIDO_EMPLEADO = empleado.APELLIDO_EMPLEADO;
                    _repositorio.EMPLEADO.Add(item);
                    _repositorio.SaveChanges();
                    retorno = true;
                    empleado.ID_EMPLEADO = item.ID_EMPLEADO;
                    _usuarioService.CrearUsuario(empleado);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
            }
            return retorno;
        }

        public bool EditarEmpleado(EmpleadoEntity empleado)
        {
            var retorno = false;
            var elemento = _repositorio.EMPLEADO.Where(x => x.DNI_EMPLEADO == empleado.DNI_EMPLEADO).FirstOrDefault();
            try
            {
                if (elemento != null)
                {

                    _repositorio.Entry(elemento).CurrentValues.SetValues(empleado);
                    _repositorio.SaveChanges();
                    retorno = true;
                    _usuarioService.EditarUsuario(empleado.USUARIOS[0]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }
            return retorno;
        }

        public List<EmpleadoEntity> ListarEmpleado()
        {
            var retorno = new List<EmpleadoEntity>();
            retorno = _repositorio.EMPLEADO.Select(x => new EmpleadoEntity
            {
                ID_EMPLEADO = x.ID_EMPLEADO,
                NOMBRE_EMPLEADO = x.NOMBRE_EMPLEADO,
                APELLIDO_EMPLEADO = x.APELLIDO_EMPLEADO,
                DNI_EMPLEADO = x.DNI_EMPLEADO
            }).ToList();
            return retorno;
        }

        public EmpleadoEntity obtenerEmpleado(EmpleadoEntity empleado)
        {
            var retorno = new EmpleadoEntity();
            retorno = _repositorio.EMPLEADO.Where(e => e.DNI_EMPLEADO == empleado.DNI_EMPLEADO)
                .Select(x => new EmpleadoEntity
                {
                    ID_EMPLEADO = x.ID_EMPLEADO,
                    NOMBRE_EMPLEADO = x.NOMBRE_EMPLEADO,
                    APELLIDO_EMPLEADO = x.APELLIDO_EMPLEADO,
                    DNI_EMPLEADO = x.DNI_EMPLEADO
                }).FirstOrDefault();
            return retorno;
        }
    }
}
