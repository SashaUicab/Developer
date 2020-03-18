using Entities;
using System;

namespace Interfaces.Business
{
    public interface IFechaEntrega
    {
        DateTime ObtenerFechaEntrega(DateTime _dtFechaPedido, int _iMinutosTiempoEntrega);
    }
}
