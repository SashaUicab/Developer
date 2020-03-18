using Interfaces.Business;
using System;

namespace Business
{
    public class MargenUtilidadDHL : IMargenUtilidad
    {
        public decimal ObtenerMargenUtilidad(DateTime _dtFechaPedido)
        {
            int iMes = _dtFechaPedido.Month;
            int iSemestre = ObtenerSemestre(iMes);
            decimal dMargen;
            switch (iSemestre)
            {
                case 1:
                    dMargen = .5M;
                    break;
                case 2:
                    dMargen = .3M;
                    break;
                default:
                    dMargen = decimal.Zero;
                    break;
            }
            return dMargen + 1;
        }

        private int ObtenerSemestre(int _iMes)
        {
            int iSemestre = 0;

            if (_iMes >= 1 && _iMes <= 6)
            {
                iSemestre = 1;
            }
            else if (_iMes >= 7 && _iMes <= 12)
            {
                iSemestre = 2;
            }
            return iSemestre;
        }
    }
}
