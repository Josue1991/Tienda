using BusinessEntity;
using BusinessService1.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Estado")]
    public class EstadoController : ApiController
    {
        IEstadoService _estadoService;
        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [Route("listar")]
        [HttpGet]
        public List<EstadoEntity> listarTodo()
        {
            return _estadoService.listaEstado();
        }
        [Route("ingresarEstado")]
        [HttpPost]
        public bool ingresarEstado([FromBody] EstadoEntity nuevo)
        {
            return _estadoService.ingresarEstado(nuevo);
        }

        [Route("editarEstado")]
        [HttpPost]
        public bool editarEstado(string descripcion, int idEstado)
        {
            var editar = new EstadoEntity();
            editar.ID_ESTADO = idEstado;
            editar.DESCRIPCION_ESTADO = descripcion;
            return _estadoService.editarEstado(editar);
        }
        [Route("eliminarEstado")]
        [HttpPost]
        public bool eliminarEstado(int idEstado)
        {
            var editar = new EstadoEntity();
            editar.ID_ESTADO = idEstado;
            return _estadoService.eliminarEstado(editar);
        }
    }
}
