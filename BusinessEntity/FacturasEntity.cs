using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class FacturasEntity
    {
        public int ID_FACTURA { get; set; }
        public Nullable<int> ID_CLIENTE { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
        public Nullable<int> ID_USUARIO { get; set; }
        public Nullable<System.DateTime> FECHA_FACTURA { get; set; }
        public Nullable<decimal> SUB_TOTAL { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public Nullable<decimal> SUB_TOTAL_IVA { get; set; }
        public ClientesEntity CLIENTE { get; set; }
        public List<DetalleFacturasEntity> DETALLE_FACTURA { get; set; }
        public EstadoEntity ESTADO { get; set; }
    }
}
