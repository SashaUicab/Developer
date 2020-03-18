using Entities;
using Interfaces.Business;
using Interfaces.Business.Factory;
using StructureMap;
using System;

namespace Business.Factory
{
    public class CostoEnvioFactory : ICostoEnvioFactory
    {
        private readonly IContainer container;

        public CostoEnvioFactory(IContainer _container)
        {
            container = _container ?? throw new ArgumentNullException(nameof(_container));
        }

        public ICostoEnvio CrearInstancia(EnumMedioTransporte _enumMedioTransporte, string _cIdentificadorEmpresa)
        {
            ICostoEnvio costoEnvio = null;
            switch (_enumMedioTransporte)
            {
                case EnumMedioTransporte.Maritimo:

                    break;
                case EnumMedioTransporte.Terrestre:

                    break;
                case EnumMedioTransporte.Aereo:
                    costoEnvio = ObtenerInstanciaCostoEnvioAereo(_cIdentificadorEmpresa);
                    break;
            }
            return costoEnvio;
        }

        private ICostoEnvio ObtenerInstanciaCostoEnvioAereo(string _cIdentificadorEmpresa)
        {
            IEscalaPorKM escalaPorKM = new EscalaPorKMAereo();
            ICargoExtraEnvio cargoExtraEnvio = new CargoExtraEnvioAereo(escalaPorKM);
            IMargenUtilidad margenUtilidad = container.GetInstance<IMargenUtilidad>(_cIdentificadorEmpresa);
            ICostoEnvio costoEnvio = new CostoEnvioAereo(cargoExtraEnvio, margenUtilidad);
            return costoEnvio;
        }
    }
}
