using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IDetalleFacturaService
    {
        bool crearDetalles(FacturasEntity faturas);
    }
}
