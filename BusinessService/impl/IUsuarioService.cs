using BusinessEntity;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IUsuarioService
    {
        UsuarioEntity Validar(UsuarioEntity login);
        bool CrearUsuario(EmpleadoEntity login);
        bool EditarUsuario(UsuarioEntity usuario);
        bool EliminarUsuario(UsuarioEntity usuario);
        List<UsuarioList> ListarUsuarios();
        UsuarioList ObtenerUsuario(UsuarioEntity usuario);
    }
}
