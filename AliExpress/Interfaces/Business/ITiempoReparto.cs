using Entities;

namespace Interfaces.Business
{
    public interface ITiempoReparto
    {
        decimal ObtenerTiempoReparto(EnumMedioTransporte _enumMedioTransporte);
    }
}
