using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class DetalleFacturasEntity
    {
        public int ID_DETALLE { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
        public Nullable<int> ID_FACTURA { get; set; }
        public Nullable<int> ID_SERVICIO { get; set; }
        public Nullable<decimal> PRECIO_TOTAL { get; set; }
        public Nullable<int> CANTIDAD_DETALLE { get; set; }

    }
}
