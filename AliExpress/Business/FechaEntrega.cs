using Entities;
using Interfaces.Business;
using System;

namespace Business
{
    public class FechaEntrega : IFechaEntrega
    {
        public DateTime ObtenerFechaEntrega(DateTime _dtFechaPedido, int _iMinutosTiempoEntrega)
        {
            DateTime dtFechaEntrega= _dtFechaPedido.AddMinutes(_iMinutosTiempoEntrega);
            return dtFechaEntrega; 
        }
    }
}
