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
    
    public partial class SERVICIO
    {
        public SERVICIO()
        {
            this.DETALLE_FACTURA = new HashSet<DETALLE_FACTURA>();
            this.DETALLESERVICIO = new HashSet<DETALLESERVICIO>();
        }
    
        public int ID_SERVICIO { get; set; }
        public string DESCRIPCION_SERVICIO { get; set; }
        public Nullable<decimal> PRECIO_SERVICIO { get; set; }
    
        public virtual ICollection<DETALLE_FACTURA> DETALLE_FACTURA { get; set; }
        public virtual ICollection<DETALLESERVICIO> DETALLESERVICIO { get; set; }
    }
}
