using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IProductoService
    {
        List<ProductoEntity> listaProductos();
        ProductoEntity obtenerProducto(int codigo);
        bool ingresarProducto(ProductoEntity objeto);
        bool editarProducto(ProductoEntity objeto);
        bool eliminarProducto(ProductoEntity objeto);
    }
}
