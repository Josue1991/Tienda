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
    [RoutePrefix("api/FormaPago")]
    public class FormaPagoController : ApiController
    {
        IFormaPagoService _formaPagoService;
        public FormaPagoController(IFormaPagoService formaPagoService)
        {
            _formaPagoService = formaPagoService;
        }

        [Route("listar")]
        [HttpGet]
        public List<FormaPagoEntity> listarTodo()
        {
            return _formaPagoService.ListaFormaPago();
        }

        [Route("insertarFormaPago")]
        [HttpPost]
        public bool insertarFormaPago([FromBody] FormaPagoEntity nuevo)
        {
            return _formaPagoService.ingresarFormaPago(nuevo);
        }

        [Route("editarFormaPago/{direccion}/{estado}")]
        [HttpPost]
        public bool editarFormaPago(string direccion, int estado)
        {
            var editar = new FormaPagoEntity();
            editar.DESCRIPCION_FORMA = direccion;
            editar.ESTADO_FORMAPAGO = estado;
            return _formaPagoService.editarFormaPago(editar);
        }
    }
}
