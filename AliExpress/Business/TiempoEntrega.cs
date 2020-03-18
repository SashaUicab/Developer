using Entities;
using Interfaces.Business;

namespace Business
{
    public class TiempoEntrega : ITiempoEntrega
    {
        private readonly ITiempoTraslado tiempoTraslado;
        private readonly ITiempoReparto tiempoReparto;

        public TiempoEntrega(ITiempoTraslado _tiempoTraslado, ITiempoReparto _tiempoReparto)
        {
            tiempoTraslado = _tiempoTraslado ?? throw new System.ArgumentNullException(nameof(_tiempoTraslado));
            tiempoReparto = _tiempoReparto ?? throw new System.ArgumentNullException(nameof(_tiempoReparto));
        }
        public decimal ObtenerTiempoEntrega(decimal _dDistancia, EnumMedioTransporte _enumMedioTransporte)
        {
            decimal dTiempoTraslado = tiempoTraslado.ObtenerTiempoTraslado(_dDistancia);
            decimal dTiempoReparto = tiempoReparto.ObtenerTiempoReparto(_enumMedioTransporte);
            return (dTiempoTraslado + dTiempoReparto);
        }
    }
}
