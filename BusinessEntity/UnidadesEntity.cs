using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class UnidadesEntity
    {
        public int ID_UNIDAD { get; set; }
        public string DESCRIPCION_UNIDAD { get; set; }
        public string ABREVIATURA_UNIDAD { get; set; }
        public Nullable<decimal> EQUIVALENCIA_UNIDAD { get; set; }


    }
}
