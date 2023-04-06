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
        IUsuarioService _usuarioService;
        public EmpleadoController(IEmpleadoService empleadoService, IUsuarioService usuarioService)
        {
            _empleadoService = empleadoService;
            _usuarioService = usuarioService;
        }
        [Route("ListarEmpleados")]
        [HttpGet]
        public List<EmpleadoEntity> ListarEmpleados()
        {
            return _empleadoService.ListarEmpleado();
        }
        [Route("ListarUsuarios")]
        [HttpGet]
        public List<UsuarioList> ListarUsuarios()
        {
            return _usuarioService.ListarUsuarios();
        }

        [Route("CrearEmpleados")]
        [HttpPost]
        public HttpResponseMessage CrearEmpleados([FromBody] EmpleadoEntity nuevo)
        {
            var retorno = new HttpResponseMessage(HttpStatusCode.NotFound);
            try
            {
                if (_empleadoService.CrearEmpleado(nuevo))
                {
                    retorno = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                retorno = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return retorno;
        }
        [Route("EditarEmpleados")]
        [HttpPost]
        public HttpResponseMessage EditarEmpleados([FromBody] EmpleadoEntity nuevo)
        {
            var retorno = new HttpResponseMessage(HttpStatusCode.NotFound);
            try
            {
                if (_empleadoService.EditarEmpleado(nuevo))
                {
                    retorno = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                retorno = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return retorno;
        }
        [Route("EditarUsuario")]
        [HttpPost]
        public HttpResponseMessage EditarUsuario([FromBody] UsuarioEntity nuevo)
        {
            var retorno = new HttpResponseMessage(HttpStatusCode.NotFound);
            try
            {
                if (_usuarioService.EditarUsuario(nuevo))
                {
                    retorno = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                retorno = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return retorno;
        }


        [Route("EliminarEmpleados")]
        [HttpPost]
        public HttpResponseMessage EliminarEmpleados([FromBody] EmpleadoEntity nuevo)
        {
            var retorno = new HttpResponseMessage(HttpStatusCode.NotFound);
            try
            {
                if (_empleadoService.BorrarEmpleado(nuevo))
                {
                    retorno = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                retorno = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return retorno;
        }
    }
}
