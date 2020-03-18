using Business.CadenaResponsabilidad;
using Entities;
using System;

namespace Business.CadenaTiempoEntregaTexto
{
    public class TextoMeses : CadenaResponsabilidadBase<TextoMinutoDTO>
    {
        private decimal dRangoInicialMes = 43200M;//30 días

        protected override void Procesar(TextoMinutoDTO _textoMinutoDTO)
        {
            string cTextoEntrega;
            if (_textoMinutoDTO.dMinutos > dRangoInicialMes)
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
            int iMeses = ObtenerMeses(_dMinutos);
            string cNumeroMeses = iMeses.ToString();
            string cTextoMeses = ObtenerTextoMeses(iMeses);
            string cTextoEntrega = $"{cNumeroMeses} {cTextoMeses}";
            return cTextoEntrega;
        }

        private int ObtenerMeses(decimal _dMinutos)
        {
            decimal dHoras = ObtenerHoras(_dMinutos);
            decimal dDias = ObtenerDiasPorHora(dHoras);
            decimal dMeses = ObtenerMesesPorDia(dDias);

            int iMeses = Convert.ToInt32(dMeses);
            return iMeses;
        }

        private decimal ObtenerMesesPorDia(decimal _dDias)
        {
            return (_dDias / 30.417M);//Valor fijo para obtener meses.
        }

        private decimal ObtenerDiasPorHora(decimal _dHoras)
        {
            return (_dHoras / 24);
        }

        private decimal ObtenerHoras(decimal _dMinutos)
        {
            decimal dHoras = (_dMinutos / 60);
            return dHoras;
        }

        private string ObtenerTextoMeses(int iMeses)
        {
            string cTexto;
            if (iMeses == 1)
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
            return "mes";
        }
        private string ObtenerNomenclaturaPlural()
        {
            return "meses";
        }
    }
}
