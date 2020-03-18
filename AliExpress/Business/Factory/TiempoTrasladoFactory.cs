using Entities;
using Interfaces.Business;
using Interfaces.Business.Factory;

namespace Business.Factory
{
    public class TiempoTrasladoFactory : ITiempoTrasladoFactory
    {
        //private readonly IContainer container;

        //public TiempoTrasladoFactory(IContainer _container)
        //{
        //    container = _container ?? throw new ArgumentNullException(nameof(_container));
        //}
        public ITiempoTraslado CrearInstancia(EnumMedioTransporte _enumMedioTransporte)
        {
            ITiempoTraslado tiempoTraslado = null;
            switch (_enumMedioTransporte)
            {
                case EnumMedioTransporte.Maritimo:
                  
                    break;
                case EnumMedioTransporte.Terrestre:
                   
                    break;
                case EnumMedioTransporte.Aereo:
                    IEscalaPorKM escalaPorKM = new EscalaPorKMAereo();
                    ITiempoExtraTraslado tiempoExtraTraslado = new TiempoExtraTrasladoAereo(escalaPorKM);
                    IVelocidadEntregaTransporte velocidadEntregaTransporte = new VelocidadEntregaTransporte();
                    tiempoTraslado = new TiempoTrasladoAereo(tiempoExtraTraslado, velocidadEntregaTransporte);
                    break;
            }
            return tiempoTraslado;
        }
    }
}
