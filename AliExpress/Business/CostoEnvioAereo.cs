using Entities;
using Interfaces.Business;
using System;

namespace Business
{
    public class CostoEnvioAereo : ICostoEnvio
    {
        private readonly ICargoExtraEnvio cargoExtraEnvio;
        private readonly IMargenUtilidad margenUtilidad;
        private decimal dTarifaUnica = 10M;

        public CostoEnvioAereo(ICargoExtraEnvio _cargoExtraEnvio, IMargenUtilidad _margenUtilidad)
        {
            cargoExtraEnvio = _cargoExtraEnvio ?? throw new ArgumentNullException(nameof(_cargoExtraEnvio));
            margenUtilidad = _margenUtilidad ?? throw new ArgumentNullException(nameof(_margenUtilidad));
        }
        public decimal ObtenerCostoEnvio(EnumEmpresa enumEmpresa, DateTime _dtFechaPedido, decimal _dtDistancia)
        {
            decimal dCargoExtraEnvio = cargoExtraEnvio.ObtenerCargoExtra(_dtDistancia);
            decimal dCostoEnvioTransporte = ObtenerCostoEnvioTransporte(_dtDistancia,dCargoExtraEnvio);
            decimal dMargenUtilidad = margenUtilidad.ObtenerMargenUtilidad(_dtFechaPedido);
            decimal dCostoEnvio = (dCostoEnvioTransporte * dMargenUtilidad);
            return dCostoEnvio;
        }

        private decimal ObtenerCostoEnvioTransporte(decimal _dtDistancia, decimal dCargoExtraEnvio)
        {
            return ((_dtDistancia * dTarifaUnica) + dCargoExtraEnvio);
        }
    }
}
