using Interfaces.Business;
using System;

namespace Business
{
    public class EscalaPorKMAereo : IEscalaPorKM
    {
        private decimal dRangoEscala = 1000M;
        public int ObtenerNumeroEscalas(decimal _dDistanciaKM)
        {
            decimal dNumeroEscala = (_dDistanciaKM/ dRangoEscala);
            int iNumeroEscalas= Convert.ToInt32(dNumeroEscala);
            return iNumeroEscalas;
        }
    }
}
