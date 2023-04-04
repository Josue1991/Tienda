using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class DetalleServicioEntity
    {
        public int ID_DETALLESERVICIO { get; set; }
        public int ID_SERVICIO { get; set; }
        public Nullable<int> ID_PRODUCTO { get; set; }
        public Nullable<decimal> CANTIDAD_DETALLE { get; set; }
        public ProductoEntity PRODUCTOS { get; set; }
        public ServiciosEntity SERVICIO { get; set; }
    }
}
