using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UsuarioList
    {
        public int ID_USUARIO { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
        public string CONTRASENA { get; set; }
        public string EMAIL { get; set; }
        public string NOMBRE_EMPLEADO { get; set; }
        public string APELLIDO_EMPLEADO { get; set; }
        public string DNI_EMPLEADO { get; set; }

    }
}
