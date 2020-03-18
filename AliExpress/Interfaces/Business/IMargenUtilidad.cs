using System;

namespace Interfaces.Business
{
    public interface IMargenUtilidad
    {
        decimal ObtenerMargenUtilidad(DateTime _dtFechaPedido);
    }
}
