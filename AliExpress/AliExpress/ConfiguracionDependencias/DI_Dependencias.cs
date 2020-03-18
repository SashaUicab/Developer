using Business;
using Interfaces.Business;
using StructureMap;

namespace AliExpress.ConfiguracionDependencias
{
    public class DI_Dependencias: Registry
    {
        public DI_Dependencias()
        {
            //Tiempo Reparto por Empresa
            For<ITiempoReparto>().Use<TiempoRepartoDHL>().Named("DHL");

            For<IMargenUtilidad>().Use<MargenUtilidadDHL>().Named("DHL");
        }

    }
}
