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
    [RoutePrefix("api/Servicios")]
    public class ServiciosController : ApiController
    {
        IServiciosService _serviciosService;
        public ServiciosController(IServiciosService serviciosService)
        {
            _serviciosService = serviciosService;
        }

        [Route("listarServicios")]
        [HttpGet]
        public List<ServiciosEntity> listarServicios()
        {
            return _serviciosService.listarServicios();
        }
        [Route("insertarServicios")]
        [HttpPost]
        public bool insertarServicios([FromBody] ServiciosEntity nuevo)
        {
            return _serviciosService.crearServicios(nuevo);
        }
        [Route("editarServicios")]
        [HttpPost]
        public bool editarServicios([FromBody] ServiciosEntity nuevo)
        {
            return _serviciosService.editarServicio(nuevo);
        }
    }
}
