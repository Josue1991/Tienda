﻿using BusinessEntity;
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
        bool Validar(UsuarioEntity login);
        bool CrearUsuario(EmpleadoEntity login);
        bool EditarUsuario(UsuarioEntity usuario);
        bool EliminarUsuario(UsuarioEntity usuario);
        List<UsuarioEntity> ListarUsuarios();
        UsuarioEntity ObtenerUsuario(UsuarioEntity usuario);
    }
}