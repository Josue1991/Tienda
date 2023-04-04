using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class ServiciosEntity
    {
        public int ID_SERVICIO { get; set; }
        public Nullable<int> ID_DETALLE { get; set; }
        public string DESCRIPCION_SERVICIO { get; set; }
        public Nullable<decimal> PRECIO_SERVICIO { get; set; }

        public DetalleFacturasEntity DETALLE_FACTURA { get; set; }
        public List<DetalleServicioEntity> DETALLESERVICIO { get; set; }
    }
}
