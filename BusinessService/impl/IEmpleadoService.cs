using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IEmpleadoService
    {
        bool CrearEmpleado(EmpleadoEntity empleado);
        bool EditarEmpleado(EmpleadoEntity empleado);
        bool BorrarEmpleado(EmpleadoEntity empleado);
        List<EmpleadoEntity> ListarEmpleado();
        EmpleadoEntity obtenerEmpleado(EmpleadoEntity empleado);
    }
}
