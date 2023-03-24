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
        List<ListaProductos> listaProductos();
        List<ListaProductos> obtenerProducto(int codigo);
        bool ingresarProducto(ProductoEntity objeto, InventarioEntity inventario);
        bool editarProducto(ProductoEntity objeto);
        bool eliminarProducto(ProductoEntity objeto);
    }
}
