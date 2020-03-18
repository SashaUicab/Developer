using Entities;
using Interfaces.Business;
using System;

namespace Business
{
    public class VelocidadEntregaTransporte : IVelocidadEntregaTransporte
    {
        private decimal dTiempoMaritimo = 46M;
        private decimal dTiempoTerrestre = 80M;
        private decimal dTiempoAereo = 600M;

        public decimal ObtenerVelocidadEntregaTransporte(EnumMedioTransporte _enumMedioTransporte)
        {
            decimal dVelocidadEntrega;
            switch (_enumMedioTransporte)
            {
                case EnumMedioTransporte.Maritimo:
                    dVelocidadEntrega = dTiempoMaritimo;
                    break;
                case EnumMedioTransporte.Terrestre:
                    dVelocidadEntrega = dTiempoTerrestre;
                    break;
                case EnumMedioTransporte.Aereo:
                    dVelocidadEntrega = dTiempoAereo;
                    break;
                default:
                    dVelocidadEntrega = decimal.Zero;
                    break;
            }
            return dVelocidadEntrega;
        }
    }
}
