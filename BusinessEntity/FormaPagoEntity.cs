using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class FormaPagoEntity
    {
        public int ID_FORMAPAGO { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
        public string DESCRIPCION_FORMA { get; set; }
        public Nullable<int> ESTADO_FORMAPAGO { get; set; }
    }
}
