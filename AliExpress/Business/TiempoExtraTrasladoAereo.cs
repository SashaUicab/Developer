using Interfaces.Business;
using System;

namespace Business
{
    public class TiempoExtraTrasladoAereo : ITiempoExtraTraslado
    {
        private readonly IEscalaPorKM escalaPorKM;
        private decimal dMinutosEscalas = 360;
        public TiempoExtraTrasladoAereo(IEscalaPorKM _escalaPorKM)
        {
            escalaPorKM = _escalaPorKM ?? throw new ArgumentNullException(nameof(_escalaPorKM));
        }
        public decimal ObtenerTiempoExtra(decimal _dDistanciaKM)
        {
            int iNumeroEscalas = escalaPorKM.ObtenerNumeroEscalas(_dDistanciaKM);
            decimal dTiempoExtra = iNumeroEscalas * dMinutosEscalas;
            return dTiempoExtra;
        }
    }
}
