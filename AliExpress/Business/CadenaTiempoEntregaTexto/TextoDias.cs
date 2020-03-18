using Business.CadenaResponsabilidad;
using Entities;
using System;

namespace Business.CadenaTiempoEntregaTexto
{
    public class TextoDias : CadenaResponsabilidadBase<TextoMinutoDTO>
    {
        private decimal dRangoInicialDia = 1380M;//23 horas
        private decimal dRangoFinalDia = 43200M;//30 días

        protected override void Procesar(TextoMinutoDTO _textoMinutoDTO)
        {
            string cTextoEntrega;
            if (_textoMinutoDTO.dMinutos > dRangoInicialDia && _textoMinutoDTO.dMinutos <= dRangoFinalDia‬)
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
            int iDias = ObtenerDias(_dMinutos);
            string cNumeroDias = iDias.ToString();
            string cTextoDias = ObtenerTextoDias(iDias);
            string cTextoEntrega = $"{cNumeroDias} {cTextoDias}";
            return cTextoEntrega;
        }

        private int ObtenerDias(decimal _dMinutos)
        {
            decimal dHoras = ObtenerHoras(_dMinutos);
            decimal dDias = ObtenerDiasPorHora(dHoras);
            int iDias = Convert.ToInt32(dDias);
            return iDias;
        }

        private decimal ObtenerDiasPorHora(decimal _dHoras)
        {
            return (_dHoras/24);
        }

        private decimal ObtenerHoras(decimal _dMinutos)
        {
            decimal dHoras = (_dMinutos / 60);
            return dHoras;
        }

        private string ObtenerTextoDias(int iDias)
        {
            string cTexto;
            if (iDias == 1)
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
            return "día";
        }
        private string ObtenerNomenclaturaPlural()
        {
            return "días";
        }
    }
}
