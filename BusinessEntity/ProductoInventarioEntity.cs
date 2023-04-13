using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class ProductoInventarioEntity
    {
        public int ID_PRODUCTO { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
        public Nullable<int> ID_UNIDAD { get; set; }
        public string DESCRIPCION_PRODUCTO { get; set; }
        public Nullable<decimal> CANTIDAD_INGRESO { get; set; }
        public Nullable<decimal> CANTIDAD_SALIDA { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> STOCK_INVENTARIO { get; set; }
        public Nullable<System.DateTime> FECHA_SALIDA { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO { get; set; }


    }
}
