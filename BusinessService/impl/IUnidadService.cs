using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IUnidadService
    {
        bool crearUnidad(UnidadesEntity objeto);
        bool editarUnidad(UnidadesEntity objeto);
        List<UnidadesEntity> listarUnidades();
        UnidadesEntity obtenerUnidades(int codigo);
    }
}
