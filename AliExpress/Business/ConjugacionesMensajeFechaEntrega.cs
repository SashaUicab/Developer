using Interfaces.Business;
using System;

namespace Business
{
    public class ConjugacionesMensajeFechaEntrega : IConjugacionesMensajeFechaEntrega
    {
        public string ObtenerConjugacionSalida(DateTime _dtFechaEntrega, DateTime _dtFechaActual)
        {
            string cMensajeFechaEntregaMenor = "salió";
            string cMensajeFechaEntregaMayor = "ha salido";
            return ObtenerMensajeFechaEntrega(_dtFechaEntrega, _dtFechaActual, cMensajeFechaEntregaMenor,cMensajeFechaEntregaMayor);
        }

        public string ObtenerConjugacionLlegada(DateTime _dtFechaEntrega, DateTime _dtFechaActual)
        {
            string cMensajeFechaEntregaMenor = "llegó";
            string cMensajeFechaEntregaMayor = "llegará";
            return ObtenerMensajeFechaEntrega(_dtFechaEntrega, _dtFechaActual, cMensajeFechaEntregaMenor, cMensajeFechaEntregaMayor);
        }

        public string ObtenerConjugacionLapsoTiempo(DateTime _dtFechaEntrega, DateTime _dtFechaActual)
        {
            string cMensajeFechaEntregaMenor = "hace";
            string cMensajeFechaEntregaMayor = "dentro de";
            return ObtenerMensajeFechaEntrega(_dtFechaEntrega, _dtFechaActual, cMensajeFechaEntregaMenor, cMensajeFechaEntregaMayor);
        }

        public string ObtenerConjugacionTener(DateTime _dtFechaEntrega, DateTime _dtFechaActual)
        {
            string cMensajeFechaEntregaMenor = "tuvo";
            string cMensajeFechaEntregaMayor = "tendrá";
            return ObtenerMensajeFechaEntrega(_dtFechaEntrega, _dtFechaActual, cMensajeFechaEntregaMenor, cMensajeFechaEntregaMayor);
        }

        private string ObtenerMensajeFechaEntrega(DateTime _dtFechaEntrega, DateTime _dtFechaActual, string _cMensajeFechaEntregaMenor, string _cMensajeFechaEntregaMayor)
        {
            string cMensaje = string.Empty;
            if (_dtFechaEntrega < _dtFechaActual)
            {
                cMensaje = _cMensajeFechaEntregaMenor;
            }
            else
            {
                cMensaje = _cMensajeFechaEntregaMayor;
            }
            return cMensaje;
        }
    }
}
