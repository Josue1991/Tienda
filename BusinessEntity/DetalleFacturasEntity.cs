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
        public Nullable<int> ID_PRODUCTO { get; set; }
        public Nullable<int> COD_FACTURA { get; set; }
        public Nullable<decimal> PRECIO_TOTAL { get; set; }
        public Nullable<decimal> PRECIO_PRODUCTO { get; set; }
        public Nullable<int> CANTIDAD_DETALLE { get; set; }
        public Nullable<int> ESTADO_DETALLE { get; set; }

        public virtual FacturasEntity FACTURA { get; set; }
        public virtual ProductoEntity PRODUCTOS { get; set; }
    }
}
