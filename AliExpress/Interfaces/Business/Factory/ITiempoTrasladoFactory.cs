using Entities;

namespace Interfaces.Business.Factory
{
    public interface ITiempoTrasladoFactory
    {
        ITiempoTraslado CrearInstancia(EnumMedioTransporte _enumMedioTransporte);
    }
}
