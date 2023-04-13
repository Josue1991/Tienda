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
        public List<ProductoInventarioEntity> listar()
        {
            return _productoService.listaProductos();
        }
        [Route("ingresarProducto")]
        [HttpPost]
        public bool ingresarProducto([FromBody] ProductoInventarioEntity objeto )
        {
            return _productoService.ingresarProducto(objeto);
        }

        [Route("editarProducto")]
        [HttpPost]
        public bool editarProducto([FromBody] ProductoInventarioEntity objeto)
        {
            return _productoService.editarProducto(objeto);
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
