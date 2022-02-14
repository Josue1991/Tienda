using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1.impl
{
    public interface IFormaPagoService
    {
        List<FormaPagoEntity> ListaFormaPago();
        FormaPagoEntity obtenerFormaPago(int codigo);
        bool ingresarFormaPago(FormaPagoEntity objeto);
        bool editarFormaPago(FormaPagoEntity objeto);
        bool eliminarFormaPago(FormaPagoEntity objeto);

    }
}
