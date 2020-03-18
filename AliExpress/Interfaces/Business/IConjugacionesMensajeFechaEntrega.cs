using System;

namespace Interfaces.Business
{
    public interface IConjugacionesMensajeFechaEntrega
    {
        string ObtenerConjugacionSalida(DateTime _dtFechaEntrega, DateTime _dtFechaActual);

        string ObtenerConjugacionLlegada(DateTime _dtFechaEntrega, DateTime _dtFechaActual);

        string ObtenerConjugacionLapsoTiempo(DateTime _dtFechaEntrega, DateTime _dtFechaActual);

        string ObtenerConjugacionTener(DateTime _dtFechaEntrega, DateTime _dtFechaActual);
    }
}
