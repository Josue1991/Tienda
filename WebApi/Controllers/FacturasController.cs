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
    [RoutePrefix("api/Facturas")]
    public class FacturasController : ApiController
    {
        IFacturaService _facturaService;
        public FacturasController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [Route("listarFacturasCli")]
        [HttpPost]
        public List<FacturasEntity> listarFacturasCli([FromBody] ClientesEntity nuevo)
        {
            return _facturaService.ListaFacturaClientes(nuevo);
        }

        [Route("crearFactura")]
        [HttpPost]
        public bool crearFactura([FromBody] FacturasEntity nuevo)
        {
            return _facturaService.crearFactura(nuevo);
        }
    }
}
