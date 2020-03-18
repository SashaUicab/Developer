using Interfaces.Business.CadenaResponsabilidad;

namespace Business.CadenaResponsabilidad
{
    public abstract class CadenaResponsabilidadBase<TTipoProcesar> : ICadenaResponsabilidad<TTipoProcesar>
    {
        protected ICadenaResponsabilidad<TTipoProcesar> siguienteResponsabilidad;
  

        public CadenaResponsabilidadBase()
        {
            siguienteResponsabilidad = null;
        }


        public ICadenaResponsabilidad<TTipoProcesar> AsignarSiguienteEslabon(ICadenaResponsabilidad<TTipoProcesar> _siguienteResponsabilidad)
        {
            siguienteResponsabilidad = _siguienteResponsabilidad;
            return siguienteResponsabilidad;
        }

        public void  ProcesarSolicitud(TTipoProcesar _tipoProcesar)
        {
            Procesar(_tipoProcesar);
            if (siguienteResponsabilidad != null )
            {
                siguienteResponsabilidad.ProcesarSolicitud(_tipoProcesar);
            }
        }

        protected abstract void Procesar(TTipoProcesar _tipoProcesar);
    }
}
