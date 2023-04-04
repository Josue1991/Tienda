using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class ClientesEntity
    {
        public int ID_CLIENTE { get; set; }
        public Nullable<int> ID_FORMAPAGO { get; set; }
        public int ID_ESTADO { get; set; }
        public string CEDULA { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<int> TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public EstadoEntity ESTADO { get; set; }
        public FormaPagoEntity FORMAPAGO { get; set; }
        public virtual List<FacturasEntity> FACTURA { get; set; }
    }
}
