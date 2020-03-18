namespace Interfaces.Business.CadenaResponsabilidad
{
    public interface ICadenaResponsabilidad<TTipoProcesar>
    {
        ICadenaResponsabilidad<TTipoProcesar> AsignarSiguienteEslabon(ICadenaResponsabilidad<TTipoProcesar> _siguienteResponsabilidad);

        void ProcesarSolicitud(TTipoProcesar _tipoProcesar);
    }
}
