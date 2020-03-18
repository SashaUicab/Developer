using Entities;
using Interfaces.Business;
using System;

namespace ViewModel
{
    public class ProcesadorInformacionPedidoPaquete
    {
        private readonly IMensajePedidoPaquete mensajePedidoPaquete;
        private readonly ITiempoEntrega tiempoEntrega;
        private readonly IFechaEntrega fechaEntrega;
        private readonly ICostoEnvio costoEnvio;

        public ProcesadorInformacionPedidoPaquete(IMensajePedidoPaquete _mensajePedidoPaquete, ITiempoEntrega _tiempoEntrega, IFechaEntrega _fechaEntrega, ICostoEnvio _costoEnvio)
        {
            mensajePedidoPaquete = _mensajePedidoPaquete ?? throw new System.ArgumentNullException(nameof(_mensajePedidoPaquete));
            tiempoEntrega = _tiempoEntrega ?? throw new ArgumentNullException(nameof(_tiempoEntrega));
            fechaEntrega = _fechaEntrega ?? throw new ArgumentNullException(nameof(_fechaEntrega));
            costoEnvio = _costoEnvio ?? throw new ArgumentNullException(nameof(_costoEnvio));
        }

        public string ObtenerInformacionPedidoPaquete(PedidoDTO _pedido, DateTime _dtFechaActual)
        {
            decimal dTiempoEntrega = tiempoEntrega.ObtenerTiempoEntrega(_pedido.dDistancia, _pedido.enumMedioTransporte);//Falta convertir a int
            int iTiempoEntrega = Convert.ToInt32(dTiempoEntrega);
            DateTime dtFechaEntrega = fechaEntrega.ObtenerFechaEntrega(_pedido.dtFechaPedido, iTiempoEntrega);
            decimal dCostoEnvio = costoEnvio.ObtenerCostoEnvio(_pedido.enumEmpresa, _pedido.dtFechaPedido, _pedido.dDistancia);
            return mensajePedidoPaquete.ObtenerMensajePedidoPaquete(_pedido, dtFechaEntrega, _dtFechaActual, dTiempoEntrega, dCostoEnvio);
        }
    }
}
