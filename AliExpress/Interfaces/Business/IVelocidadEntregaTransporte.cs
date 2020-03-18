using Entities;

namespace Interfaces.Business
{
    public interface IVelocidadEntregaTransporte
    {
        decimal ObtenerVelocidadEntregaTransporte(EnumMedioTransporte _enumMedioTransporte);
    }
}
