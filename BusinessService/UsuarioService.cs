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
    public class UsuarioService : IUsuarioService
    {
        base1Entities _repositorio;
        public UsuarioService()
        {
            _repositorio = new base1Entities();
        }

        public bool CrearUsuario(EmpleadoEntity login)
        {
            var retorno = false;
            var elemento = _repositorio.USUARIOS.Where(x => x.EMPLEADO.DNI_EMPLEADO == login.DNI_EMPLEADO).FirstOrDefault();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.ToLower().Contains("activo")).FirstOrDefault();

            try
            {
                if (elemento == null)
                {
                    using (var context = new base1Entities())
                    {
                        var item = new USUARIOS();
                        item.COD_EMPLEADO = login.ID_EMPLEADO;
                        item.EMAIL = login.Usuarios[0].EMAIL;
                        item.CONTRASENA = login.Usuarios[0].CONTRASENA;
                        item.ESTADO = estado;
                        context.USUARIOS.Add(item);
                        context.SaveChanges();
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!", ex);
            }
            return retorno;
        }

        public bool EditarUsuario(UsuarioEntity usuario)
        {
            var retorno = false;
            var elemento = _repositorio.USUARIOS.Where(x => x.COD_EMPLEADO == usuario.COD_EMPLEADO).FirstOrDefault();
            try
            {
                if (elemento != null)
                {
                    using (var context = new base1Entities())
                    {
                        context.Entry(elemento).CurrentValues.SetValues(usuario);
                        context.SaveChanges();
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }
            return retorno;
        }

        public bool EliminarUsuario(UsuarioEntity usuario)
        {
            var retorno = false;
            var elemento = _repositorio.USUARIOS.Where(x => x.COD_EMPLEADO == usuario.COD_EMPLEADO).FirstOrDefault();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.ToLower().Contains("activo")).FirstOrDefault();
            try
            {
                if (elemento != null)
                {
                    using (var context = new base1Entities())
                    {
                        usuario.ID_ESTADO = estado.ID_ESTADO;
                        context.Entry(elemento).CurrentValues.SetValues(usuario);
                        context.SaveChanges();
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }
            return retorno;
        }

        public List<UsuarioList> ListarUsuarios()
        {
            var retorno = new List<UsuarioList>();
            retorno = _repositorio.USUARIOS.Select(x => new UsuarioList
            {
                ID_USUARIO = x.ID_USUARIO,
                ID_ESTADO = x.ID_ESTADO,
                CONTRASENA = x.CONTRASENA,
                EMAIL = x.EMAIL,
                NOMBRE_EMPLEADO = x.EMPLEADO.NOMBRE_EMPLEADO,
                APELLIDO_EMPLEADO = x.EMPLEADO.APELLIDO_EMPLEADO,
                DNI_EMPLEADO = x.EMPLEADO.DNI_EMPLEADO
            }).ToList();
            return retorno;
        }

        public UsuarioList ObtenerUsuario(UsuarioEntity usuario)
        {
            var retorno = new UsuarioList();
            retorno = _repositorio.USUARIOS
                .Select(x => new UsuarioList
                {
                    ID_USUARIO = x.ID_USUARIO,
                    ID_ESTADO = x.ID_ESTADO,
                    CONTRASENA = x.CONTRASENA,
                    EMAIL = x.EMAIL,
                    NOMBRE_EMPLEADO = x.EMPLEADO.NOMBRE_EMPLEADO,
                    APELLIDO_EMPLEADO = x.EMPLEADO.APELLIDO_EMPLEADO,
                    DNI_EMPLEADO = x.EMPLEADO.DNI_EMPLEADO
                }).FirstOrDefault();
            return retorno;
        }

        public bool Validar(UsuarioEntity login)
        {
            var retorno = false;

            var buscar = _repositorio.USUARIOS.Where(x => x.EMAIL == login.EMAIL && x.CONTRASENA == login.CONTRASENA).FirstOrDefault();
            if (buscar != null)
            {
                retorno = true;
            }
            return retorno;
        }

        List<UsuarioEntity> IUsuarioService.ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        UsuarioEntity IUsuarioService.ObtenerUsuario(UsuarioEntity usuario)
        {
            throw new NotImplementedException();
        }
    }
}

