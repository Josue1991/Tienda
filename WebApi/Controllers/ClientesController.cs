using BusinessEntity;
using BusinessService1.impl;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [Route("listar")]
        [HttpGet]
        public List<ClientesEntity> listarTodo()
        {
            return _clienteService.ListaCliente();
        }
        [Route("insertarCliente")]
        [HttpPost]
        public bool insertarClientes([FromBody] ClientesEntity nuevo)
        {
            return _clienteService.ingresarCliente(nuevo);
        }
        //Cambiar Controlador para que reciba una entidad y no tantos parametros

        [Route("editarCliente")]
        [HttpPost]
        public bool editarClientes(string direccion,int telefono,string email,string cedula)
        {
            var editar = new ClientesEntity();
            editar.DIRECCION = direccion;
            editar.TELEFONO = telefono;
            editar.EMAIL = email;
            editar.CEDULA = cedula;
            return _clienteService.editarCliente(editar);
        }
    }
}
