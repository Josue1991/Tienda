using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IFacturaService
    {
        List<FacturasEntity> ListaFacturaClientes(ClientesEntity objeto);
        bool crearFactura(FacturasEntity objeto);
        bool editarFactura(ClientesEntity objeto);
        bool anularFactura(ClientesEntity objeto, int factura);
    }
}
