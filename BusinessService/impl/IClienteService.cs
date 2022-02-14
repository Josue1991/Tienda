using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IClienteService
    {
        List<ClientesEntity> ListaCliente();
        ClientesEntity obtenerCliente(string cedula, int estado);
        bool ingresarCliente(ClientesEntity cliente);
        bool editarCliente(ClientesEntity cliente);
    }
}
