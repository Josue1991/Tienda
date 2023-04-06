using DataModel;
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
        public Nullable<int> ID_ESTADO { get; set; }
        public Nullable<int> ID_UNIDAD { get; set; }
        public string DESCRIPCION_PRODUCTO { get; set; }

        public List<DetalleServicioEntity> DETALLESERVICIO { get; set; }
        public List<InventarioEntity> INVENTARIO { get; set; }
    }
}
