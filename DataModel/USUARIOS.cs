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
    
    public partial class USUARIOS
    {
        public USUARIOS()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
        }
    
        public int ID_USUARIO { get; set; }
        public int ID_EMPLEADO { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
        public string CONTRASENA { get; set; }
        public string EMAIL { get; set; }
    
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual ESTADO ESTADO { get; set; }
    }
}
