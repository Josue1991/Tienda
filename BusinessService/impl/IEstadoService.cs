using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IEstadoService
    {
        List<EstadoEntity> listaEstado();
        EstadoEntity obtenerEstado(int codigo);
        bool ingresarEstado(EstadoEntity objeto);
        bool editarEstado(EstadoEntity objeto);
        bool eliminarEstado(EstadoEntity objeto);
    }
}
