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
    public class UnidadController : ApiController
    {
        IUnidadService _unidadService;
        public UnidadController(IUnidadService unidadService)
        {
            _unidadService = unidadService;
        }

        [Route("listarUnidades")]
        [HttpGet]
        public List<UnidadesEntity> listarUnidades()
        {
            return _unidadService.listarUnidades();
        }
        [Route("insertarUnidad")]
        [HttpPost]
        public bool insertarUnidad([FromBody] UnidadesEntity nuevo)
        {
            return _unidadService.crearUnidad(nuevo);
        }
        [Route("editarUnidad")]
        [HttpPost]
        public bool editarUnidad([FromBody] UnidadesEntity nuevo)
        {
            return _unidadService.editarUnidad(nuevo);
        }
    }
}
