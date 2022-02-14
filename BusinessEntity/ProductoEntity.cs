using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class ProductoEntity
    {
        public int ID_PRODUCTO { get; set; }
        public string DESCRIPCION_PRODUCTO { get; set; }
        public Nullable<int> CANTIDAD_PRODUCTO { get; set; }
        public Nullable<decimal> PRECIO_UNITARIO { get; set; }
        public int ESTADO_PRODUCTO { get; set; }
    }
}
