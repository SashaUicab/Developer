using Business.CadenaResponsabilidad;
using Entities;
using System;

namespace Business.CadenaTiempoEntregaTexto
{
    public class TextoHoras : CadenaResponsabilidadBase<TextoMinutoDTO>
    {
        private decimal dRangoInicialHora = 59M;
        private decimal dRangoFinalHora = 1380;//23 horas
        protected override void Procesar(TextoMinutoDTO _textoMinutoDTO)
        {
            string cTextoEntrega;
            if (_textoMinutoDTO.dMinutos > dRangoInicialHora && _textoMinutoDTO.dMinutos <= dRangoFinalHora)
            {
                cTextoEntrega = ObtenerTextoEntrega(_textoMinutoDTO.dMinutos);
                AsignarTextoEntrega(cTextoEntrega, _textoMinutoDTO);
                base.siguienteResponsabilidad = null;
            }
        }

        private void AsignarTextoEntrega(string _cTextoEntrega, TextoMinutoDTO _textoMinutoDTO)
        {
            _textoMinutoDTO.cTextoTransformado = _cTextoEntrega;
        }
        private string ObtenerTextoEntrega(decimal _dMinutos)
        {
            int iHoras = ObtenerHoras(_dMinutos);
            string cNumeroHoras = iHoras.ToString();
            string cTextoHoras = ObtenerTextoHoras(iHoras);
            string cTextoEntrega = $"{cNumeroHoras} {cTextoHoras}";
            return cTextoEntrega;
        }

        private int ObtenerHoras(decimal _dMinutos)
        {
            decimal dHoras = (_dMinutos / 60);
            int iHoras = Convert.ToInt32(dHoras);
            return iHoras;
        }
        private string ObtenerTextoHoras(int iHoras)
        {
            string cTexto;
            if (iHoras == 1)
            {
                cTexto = ObtenerNomenclaturaSingular();
            }
            else
            {
                cTexto = ObtenerNomenclaturaPlural();
            }
            return cTexto;
        }

        private string ObtenerNomenclaturaSingular()
        {
            return "hora";
        }
        private string ObtenerNomenclaturaPlural()
        {
            return "horas";
        }
    }
}
