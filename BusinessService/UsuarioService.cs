using BusinessEntity;
using BusinessService1.impl;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
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
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.Contains("activo"));
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    if (elemento == null)
                    {
                        var item = new USUARIOS();
                        item.ID_EMPLEADO = login.ID_EMPLEADO;
                        item.EMAIL = login.USUARIOS[0].EMAIL;
                        item.CONTRASENA = GetMd5HashWithMySecurityAlgo(md5Hash, login.USUARIOS[0].CONTRASENA);
                        item.ID_ESTADO = estado != null ? estado.FirstOrDefault().ID_ESTADO : 0;
                        _repositorio.USUARIOS.Add(item);
                        _repositorio.SaveChanges();
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
            var elemento = _repositorio.USUARIOS.Where(x => x.EMAIL == usuario.EMAIL).FirstOrDefault();
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
            var elemento = _repositorio.USUARIOS.Where(x => x.ID_EMPLEADO == usuario.ID_EMPLEADO).FirstOrDefault();
            var estado = _repositorio.ESTADO.Where(x => x.DESCRIPCION_ESTADO.Contains("activo")).FirstOrDefault();
            try
            {
                if (elemento != null)
                {
                    usuario.ID_ESTADO = estado.ID_ESTADO;
                    _repositorio.Entry(elemento).CurrentValues.SetValues(usuario);
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

            var buscar = _repositorio.USUARIOS.Where(x => x.EMAIL == login.EMAIL).FirstOrDefault();
            using (MD5 md5Hash = MD5.Create())
            {
                if (buscar != null)
                {
                    if (VerifyMd5HashWithMySecurityAlgo(md5Hash, login.CONTRASENA,buscar.CONTRASENA))
                    {
                        retorno = true;
                    }
                }
            }
            return retorno;
        }

        static string GetMd5HashWithMySecurityAlgo(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.  
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.  
            return sBuilder.ToString();
        }
        // Verify a hash against a string.  
        static bool VerifyMd5HashWithMySecurityAlgo(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.  
            string hashOfInput = GetMd5HashWithMySecurityAlgo(md5Hash, input);
            // Create a StringComparer an compare the hashes.  
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

