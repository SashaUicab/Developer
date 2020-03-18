using Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CargoExtraEnvioAereo : ICargoExtraEnvio
    {
        private readonly IEscalaPorKM escalaPorKM;
        private decimal dCostoEscala = 200M;
        public CargoExtraEnvioAereo(IEscalaPorKM _escalaPorKM)
        {
            escalaPorKM = _escalaPorKM ?? throw new ArgumentNullException(nameof(_escalaPorKM));
        }
        public decimal ObtenerCargoExtra(decimal _dDistanciaKM)
        {
            int iNumeroEscalas = escalaPorKM.ObtenerNumeroEscalas(_dDistanciaKM);
            decimal dCargoExtra = iNumeroEscalas * dCostoEscala;
            return dCargoExtra;
        }
    }
}
