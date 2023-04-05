using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IServiciosService
    {
        bool crearServicios(ServiciosEntity objeto);
        bool editarServicio(ServiciosEntity objeto);
        List<ServiciosEntity> listarServicios();
        ServiciosEntity obtenerServicios(ServiciosEntity objeto);
    }
}
