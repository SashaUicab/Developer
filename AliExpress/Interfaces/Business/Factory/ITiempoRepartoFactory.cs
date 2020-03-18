using Entities;

namespace Interfaces.Business.Factory
{
    public interface ITiempoRepartoFactory
    {
        ITiempoReparto CrearInstancia(EnumEmpresa enumEmpresa);
    }
}
