//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLEADO
    {
        public EMPLEADO()
        {
            this.USUARIOS = new HashSet<USUARIOS>();
        }
    
        public int ID_EMPLEADO { get; set; }
        public string NOMBRE_EMPLEADO { get; set; }
        public string APELLIDO_EMPLEADO { get; set; }
        public string DNI_EMPLEADO { get; set; }
    
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
