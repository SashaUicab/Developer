using Entities;

namespace Interfaces.Business.Factory
{
    public interface ICostoEnvioFactory
    {
        ICostoEnvio CrearInstancia(EnumMedioTransporte _enumMedioTransporte, string _cIdentificadorEmpresa);
    }
}
