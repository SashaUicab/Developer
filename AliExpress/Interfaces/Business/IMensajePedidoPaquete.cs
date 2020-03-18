using Entities;
using System;

namespace Interfaces.Business
{
    public interface IMensajePedidoPaquete
    {
        string ObtenerMensajePedidoPaquete(PedidoDTO _pedido, DateTime _dtFechaEntrega, DateTime _dtFechaActual, decimal _dMinutosTiempoEntrega, decimal _dCostoEnvio);
    }
}
