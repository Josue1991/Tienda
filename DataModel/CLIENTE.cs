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
    
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            this.FACTURA = new HashSet<FACTURA>();
        }
    
        public int ID_CLIENTE { get; set; }
        public Nullable<int> ID_FORMAPAGO { get; set; }
        public string CEDULA { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<int> TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> ESTADO_CLIENTE { get; set; }
    
        public virtual FORMAPAGO FORMAPAGO { get; set; }
        public virtual ICollection<FACTURA> FACTURA { get; set; }
    }
}
