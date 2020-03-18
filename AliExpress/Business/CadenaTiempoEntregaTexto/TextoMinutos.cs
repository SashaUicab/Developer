using Business.CadenaResponsabilidad;
using Entities;
using System;

namespace Business.CadenaTiempoEntregaTexto
{
    public class TextoMinutos : CadenaResponsabilidadBase<TextoMinutoDTO>
    {
        protected override void Procesar(TextoMinutoDTO _textoMinutoDTO)
        {
            if (_textoMinutoDTO.dMinutos <= 59)
            {
                string cTextoEntrega=ObtenerTextoEntrega(_textoMinutoDTO.dMinutos);
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
            int iMinutos = ObtenerMinutosEnteros(_dMinutos);
            string cNumeroMinutos = iMinutos.ToString();
            string cTextoMinutos = ObtenerTextoMinutos(_dMinutos);
            string cTextoEntrega = $"{cNumeroMinutos} {cTextoMinutos}";
            return cTextoEntrega;
        }

        private int ObtenerMinutosEnteros(decimal _dMinutos)
        {
            return Convert.ToInt32(_dMinutos);
        }
        private string ObtenerTextoMinutos(decimal _dMinutos)
        {
            string cTexto;
            if (_dMinutos==1)
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
            return "minuto";
        }
        private string ObtenerNomenclaturaPlural()
        {
            return "minutos";
        }
    }
}
