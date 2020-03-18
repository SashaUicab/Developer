using Interfaces.Business;
using System;

namespace Business
{
    public class TiempoTrasladoAereo : ITiempoTraslado
    {
        private readonly ITiempoExtraTraslado tiempoExtraTraslado;
        private readonly IVelocidadEntregaTransporte velocidadEntregaTransporte;

        public TiempoTrasladoAereo(ITiempoExtraTraslado _tiempoExtraTraslado, IVelocidadEntregaTransporte _velocidadEntregaTransporte)
        {
            tiempoExtraTraslado = _tiempoExtraTraslado ?? throw new ArgumentNullException(nameof(_tiempoExtraTraslado));
            velocidadEntregaTransporte = _velocidadEntregaTransporte ?? throw new ArgumentNullException(nameof(_velocidadEntregaTransporte));
        }

        public decimal ObtenerTiempoTraslado(decimal _dDistanciaKM)
        {
            decimal dVelocidadKM = velocidadEntregaTransporte.ObtenerVelocidadEntregaTransporte(Entities.EnumMedioTransporte.Aereo);
            ValidarValorCero(dVelocidadKM, "velocidad");
            decimal dTiempoTraslado = ObtenerTiempoTrasladoTransporte(_dDistanciaKM, dVelocidadKM);
            decimal dTiempoExtraTraslado = tiempoExtraTraslado.ObtenerTiempoExtra(_dDistanciaKM);
            dTiempoTraslado = (ConvertirHoraAMinutos(dTiempoTraslado) + dTiempoExtraTraslado);
            return dTiempoTraslado;
        }

        private decimal ObtenerTiempoTrasladoTransporte(decimal _dDistanciaKM, decimal _dVelocidadKM)
        {
            return (_dDistanciaKM / _dVelocidadKM);
        }

        private decimal ConvertirHoraAMinutos(decimal _dTiempoTraslado)
        {
            return _dTiempoTraslado * 60;
        }

        private void ValidarValorCero(decimal _dValor, string _cNombreValor)
        {
            if (_dValor == decimal.Zero)
            {
                throw new DivideByZeroException($"El rango del valor {_cNombreValor} no puede ser cero");
            }
        }
    }
}
