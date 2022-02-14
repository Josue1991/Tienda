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
        public List<ProductoEntity> listarTodo()
        {
            return _productoService.listaProductos();
        }
        [Route("ingresarEstado")]
        [HttpPost]
        public bool ingresarEstado([FromBody] ProductoEntity nuevo)
        {
            return _productoService.ingresarProducto(nuevo);
        }

        [Route("editarEstado")]
        [HttpPost]
        public bool editarEstado(string descripcion, int idEstado)
        {
            var editar = new ProductoEntity();
            editar.ID_PRODUCTO = idEstado;
            editar.DESCRIPCION_PRODUCTO = descripcion;
            return _productoService.editarProducto(editar);
        }
        [Route("eliminarEstado")]
        [HttpPost]
        public bool eliminarEstado(int idEstado)
        {
            var editar = new ProductoEntity();
            editar.ID_PRODUCTO = idEstado;
            return _productoService.eliminarProducto(editar);
        }
    }
}
