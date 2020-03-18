using Entities;
using Interfaces.Business;

namespace Business
{
    public class TiempoRepartoDHL : ITiempoReparto
    {
        private decimal dTiempoMaritimo = 1200M; //20 horas
        private decimal dTiempoTerrestre=720M;//12 horas
        private decimal dTiempoAereo=180M;//3 horas

        public decimal ObtenerTiempoReparto(EnumMedioTransporte _enumMedioTransporte)
        {
            decimal dTiempoReparto;
            switch (_enumMedioTransporte)
            {
                case EnumMedioTransporte.Maritimo:
                    dTiempoReparto = dTiempoMaritimo;
                    break;
                case EnumMedioTransporte.Terrestre:
                    dTiempoReparto = dTiempoTerrestre;
                    break;
                case EnumMedioTransporte.Aereo:
                    dTiempoReparto = dTiempoAereo;
                    break;
                default:
                    dTiempoReparto = decimal.Zero;
                    break;
            }
            return dTiempoReparto;
        }
    }
}
