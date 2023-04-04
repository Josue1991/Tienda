using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UsuarioEntity
    {
        public int ID_USUARIO { get; set; }
        public Nullable<int> COD_EMPLEADO { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
        public string CONTRASENA { get; set; }
        public string EMAIL { get; set; }

        public EmpleadoEntity EMPLEADO { get; set; }

    }
}
