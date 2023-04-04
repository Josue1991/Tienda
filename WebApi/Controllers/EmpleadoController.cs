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
    [RoutePrefix("api/Empleados")]
    public class EmpleadoController : ApiController
    {
        IEmpleadoService _empleadoService;
        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService= empleadoService;  
        }
        [Route("listarEmpleados")]
        [HttpGet]
        public List<EmpleadoEntity> listarEmpleados()
        {
            return _empleadoService.ListarEmpleado();
        }

        [Route("crearEmpleados")]
        [HttpPost]
        public bool crearEmpleados([FromBody] EmpleadoEntity nuevo)
        {
            return _empleadoService.CrearEmpleado(nuevo);
        }
        [Route("editarEmpleados")]
        [HttpPost]
        public bool editarEmpleados([FromBody] EmpleadoEntity nuevo)
        {
            return _empleadoService.CrearEmpleado(nuevo);
        }

    }
}
