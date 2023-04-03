using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class EmpleadoEntity
    {
        public int ID_EMPLEADO { get; set; }
        public string NOMBRE_EMPLEADO { get; set; }
        public string APELLIDO_EMPLEADO { get; set; }
        public string DNI_EMPLEADO { get; set; }
        public List<UsuarioEntity> Usuarios { get; set; }
    }
}
