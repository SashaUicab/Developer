using Entities;

namespace Interfaces.Business
{
    public interface ITiempoEntrega
    {
        //  decimal ObtenerTiempoEntrega(decimal _dTiempoTraslado, decimal _dTiempoReparto);
        decimal ObtenerTiempoEntrega(decimal _dDistancia, EnumMedioTransporte _enumMedioTransporte);
    }
}
