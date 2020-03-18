using Entities;
using Interfaces.Business;
using System;

namespace Business
{
    public class MensajePedidoPaquete : IMensajePedidoPaquete
    {
        private readonly IConjugacionesMensajeFechaEntrega conjugacionesMensajeFechaEntrega;
        private readonly ICadenaTiempoEntrega cadenaTiempoEntrega;
        private readonly ICadenaCostoEnvio cadenaCostoEnvio;

        public MensajePedidoPaquete(IConjugacionesMensajeFechaEntrega _conjugacionesMensajeFechaEntrega, ICadenaTiempoEntrega _cadenaTiempoEntrega, ICadenaCostoEnvio _cadenaCostoEnvio)
        {
            conjugacionesMensajeFechaEntrega = _conjugacionesMensajeFechaEntrega ?? throw new ArgumentNullException(nameof(_conjugacionesMensajeFechaEntrega));
            cadenaTiempoEntrega = _cadenaTiempoEntrega ?? throw new ArgumentNullException(nameof(_cadenaTiempoEntrega));
            cadenaCostoEnvio = _cadenaCostoEnvio ?? throw new ArgumentNullException(nameof(_cadenaCostoEnvio));
        }

        public string ObtenerMensajePedidoPaquete(PedidoDTO _pedido, DateTime _dtFechaEntrega, DateTime _dtFechaActual, decimal _dMinutosTiempoEntrega, decimal _dCostoEnvio)
        {
            string cSalida = conjugacionesMensajeFechaEntrega.ObtenerConjugacionSalida(_dtFechaEntrega, _dtFechaActual);//[Expresión1]
            string cOrigen = $"{_pedido.cNombreCiudadOrigen}, {_pedido.cNombrePaisOrigen}";//[Origen]
            string cLlegada = conjugacionesMensajeFechaEntrega.ObtenerConjugacionLlegada(_dtFechaEntrega, _dtFechaActual);//[Expresión2]
            string cDestino = $"{_pedido.cNombreCiudadDestino}, {_pedido.cNombrePaisDestino}";//[Destino]
            string cLapsoTiempo = conjugacionesMensajeFechaEntrega.ObtenerConjugacionLapsoTiempo(_dtFechaEntrega, _dtFechaActual);//[Expresión3]
            string cRangoTiempo = cadenaTiempoEntrega.ObtenerCadenaTiempoEntrega(_dMinutosTiempoEntrega);//[Rango de Tiempo]
            string cTener = conjugacionesMensajeFechaEntrega.ObtenerConjugacionTener(_dtFechaEntrega, _dtFechaActual);//[Expresión4]

            string cCostoEnvio = cadenaCostoEnvio.ObtenerCadenaCostoEnvio(_dCostoEnvio);//[Costode envío]
            //            Tu paquete ha salido de Pekin, China y llegará a Cancún, México dentro de 4 meses y tendrá un
            //costo de $6,829,800(Cualquier reclamación con DHL).

            //            Tu paquete[Expresión1] de[Origen] y[Expresión2] a[Destino]
            //[Expresión3][Rango de Tiempo] y[Expresión4] un costo de[Costode envío](Cualquier reclamación con[Paquetería]).
            string cMensaje = $"Tu paquete {cSalida} de {cOrigen} y {cLlegada} a {cDestino} {cLapsoTiempo} {cRangoTiempo} y " +
                $"{cTener} un costo de {cCostoEnvio}(Cualquier reclamación con {_pedido.cNombrePaqueteria}).";
            return cMensaje;
        }
    }
}

