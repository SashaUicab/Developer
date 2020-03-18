using Entities;
using System;

namespace Interfaces.Business
{
    public interface ICostoEnvio
    {
        decimal ObtenerCostoEnvio(EnumEmpresa enumEmpresa, DateTime _dtFechaPedido, decimal _dtDistancia);
    }
}
