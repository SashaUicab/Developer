using Business.CadenaTiempoEntregaTexto;
using Entities;
using Interfaces.Business;

namespace Business
{
    public class CadenaTiempoEntrega : ICadenaTiempoEntrega
    {
        public string ObtenerCadenaTiempoEntrega(decimal _dMinutosEntrega)
        {
            TextoMinutoDTO textoMinutoDTO = new TextoMinutoDTO();
            textoMinutoDTO.dMinutos = _dMinutosEntrega;
            textoMinutoDTO.cTextoTransformado = string.Empty;
            TextoMinutos textoMinutos = new TextoMinutos();
            TextoHoras textoHoras = new TextoHoras();
            TextoDias textoDias = new TextoDias();
            TextoMeses textoMeses = new TextoMeses();

            textoMinutos.AsignarSiguienteEslabon(textoHoras).
                AsignarSiguienteEslabon(textoDias).
                AsignarSiguienteEslabon(textoMeses);
            textoMinutos.ProcesarSolicitud(textoMinutoDTO);

            return textoMinutoDTO.cTextoTransformado;
        }
    }
}
