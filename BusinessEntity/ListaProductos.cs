using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class ListaProductos
    {
        public int ID_PRODUCTO { get; set; }
        public string DESCRIPCION_PRODUCTO { get; set; }
        public decimal? STOCK { get; set; }
        public decimal? PRECIO_UNITARIO { get; set; }
    }
}
