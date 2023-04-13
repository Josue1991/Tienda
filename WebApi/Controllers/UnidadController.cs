using BusinessEntity;
using BusinessService1.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Unidad")]
    public class UnidadController : ApiController
    {
        IUnidadService _unidadService;
        public UnidadController(IUnidadService unidadService)
        {
            _unidadService = unidadService;
        }

        [Route("ListarUnidades")]
        [HttpGet]
        public List<UnidadesEntity> ListarUnidades()
        {
            return _unidadService.listarUnidades();
        }
        [Route("InsertarUnidad")]
        [HttpPost]
        public bool InsertarUnidad([FromBody] UnidadesEntity nuevo)
        {
            return _unidadService.crearUnidad(nuevo);
        }
        [Route("EditarUnidad")]
        [HttpPost]
        public bool EditarUnidad([FromBody] UnidadesEntity nuevo)
        {
            return _unidadService.editarUnidad(nuevo);
        }
    }
}
