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
    [RoutePrefix("api/Producto")]
    public class ProductosController : ApiController
    {
        IProductoService _productoService;
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        [Route("listar")]
        [HttpGet]
        public List<ProductoEntity> listar()
        {
            return _productoService.listaProductos();
        }
        [Route("ingresarProducto")]
        [HttpPost]
        public bool ingresarProducto([FromBody] ProductoEntity nuevo)
        {
            return _productoService.ingresarProducto(nuevo);
        }

        [Route("editarProducto")]
        [HttpPost]
        public bool editarProducto(string descripcion, int idEstado)
        {
            var editar = new ProductoEntity();
            editar.ID_PRODUCTO = idEstado;
            editar.DESCRIPCION_PRODUCTO = descripcion;
            return _productoService.editarProducto(editar);
        }
        [Route("eliminarProducto")]
        [HttpPost]
        public bool eliminarProducto(int idEstado)
        {
            var editar = new ProductoEntity();
            editar.ID_PRODUCTO = idEstado;
            return _productoService.eliminarProducto(editar);
        }
    }
}
