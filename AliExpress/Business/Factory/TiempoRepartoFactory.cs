using Entities;
using Interfaces.Business;
using Interfaces.Business.Factory;
using StructureMap;
using System;

namespace Business.Factory
{
    public class TiempoRepartoFactory : ITiempoRepartoFactory
    {
        private readonly IContainer container;

        public TiempoRepartoFactory(IContainer _container)
        {
            container = _container ?? throw new ArgumentNullException(nameof(_container));
        }
        public ITiempoReparto CrearInstancia(EnumEmpresa enumEmpresa)
        {
            string cNombreInstancia = string.Empty;
            switch (enumEmpresa)
            {
                case EnumEmpresa.Fedex:
                    cNombreInstancia = "Fedex";
                    break;
                case EnumEmpresa.DHL:
                    cNombreInstancia = "DHL";
                    break;
                case EnumEmpresa.Estafeta:
                    cNombreInstancia = "Estafeta";
                    break;
            }
            ITiempoReparto tiempoReparto = container.GetInstance<ITiempoReparto>(cNombreInstancia);//Pendiente llenar los pedidos DTO
            return tiempoReparto;
        }
    }
}
