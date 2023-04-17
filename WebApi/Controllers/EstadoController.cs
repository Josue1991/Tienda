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

        [Route("ListarEstados")]
        [HttpGet]
        public List<EstadoEntity> ListarEstados()
        {
            return _estadoService.listaEstado();
        }
        [Route("IngresarEstado")]
        [HttpPost]
        public bool IngresarEstado([FromBody] EstadoEntity nuevo)
        {
            return _estadoService.ingresarEstado(nuevo);
        }

        [Route("EditarEstado")]
        [HttpPost]
        public bool EditarEstado(string descripcion, int idEstado)
        {
            var editar = new EstadoEntity();
            editar.ID_ESTADO = idEstado;
            editar.DESCRIPCION_ESTADO = descripcion;
            return _estadoService.editarEstado(editar);
        }
        [Route("EliminarEstado")]
        [HttpPost]
        public bool EliminarEstado(int idEstado)
        {
            var editar = new EstadoEntity();
            editar.ID_ESTADO = idEstado;
            return _estadoService.eliminarEstado(editar);
        }
    }
}
