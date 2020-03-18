using Business.CadenaTiempoEntregaTexto;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessUTest.CadenaTiempoEntrega
{
    [TestClass]
    public class TextoMinutosUTest
    {
        [TestMethod]
        public void Procesar_ObtenerTextoMinutos_30Minutos()
        {
            //Arrange
            TextoMinutoDTO textoMinutoDTO = new TextoMinutoDTO();
            textoMinutoDTO.dMinutos = 30M;
            string cTextoEsperado = "30 minutos";
            TextoMinutos textoMinutos = new TextoMinutos();
            TextoHoras textoHoras = new TextoHoras();
            textoMinutos.AsignarSiguienteEslabon(textoHoras);

            //Act
            textoMinutos.ProcesarSolicitud(textoMinutoDTO);

            //Assert
            Assert.AreEqual(cTextoEsperado, textoMinutoDTO.cTextoTransformado);
        }

        [TestMethod]
        public void Procesar_ObtenerTextoHoras_23Horas()
        {
            //Arrange
            TextoMinutoDTO textoMinutoDTO = new TextoMinutoDTO();
            textoMinutoDTO.dMinutos = 1380M;
            string cTextoEsperado = "23 horas";
            TextoMinutos textoMinutos = new TextoMinutos();
            TextoHoras textoHoras = new TextoHoras();
            textoMinutos.AsignarSiguienteEslabon(textoHoras);

            //Act
            textoMinutos.ProcesarSolicitud(textoMinutoDTO);
         
            //Assert
            Assert.AreEqual(cTextoEsperado, textoMinutoDTO.cTextoTransformado);
        }

        [TestMethod]
        public void Procesar_ObtenerTextoDias_30dias()
        {
            //Arrange
            TextoMinutoDTO textoMinutoDTO = new TextoMinutoDTO();
            textoMinutoDTO.dMinutos = 43200M;
            string cTextoEsperado = "30 días";
            TextoMinutos textoMinutos = new TextoMinutos();
            TextoHoras textoHoras = new TextoHoras();
            TextoDias textoDias = new TextoDias();
            textoMinutos.AsignarSiguienteEslabon(textoHoras).
                AsignarSiguienteEslabon(textoDias);

            //Act
            textoMinutos.ProcesarSolicitud(textoMinutoDTO);

            //Assert
            Assert.AreEqual(cTextoEsperado, textoMinutoDTO.cTextoTransformado);
        }

        [TestMethod]
        public void Procesar_ObtenerTextoMeses_4Meses()
        {
            //Arrange
            TextoMinutoDTO textoMinutoDTO = new TextoMinutoDTO();
            textoMinutoDTO.dMinutos = 172800M;
            string cTextoEsperado = "4 meses";
            TextoMinutos textoMinutos = new TextoMinutos();
            TextoHoras textoHoras = new TextoHoras();
            TextoDias textoDias = new TextoDias();
            TextoMeses textoMeses = new TextoMeses();
            textoMinutos.AsignarSiguienteEslabon(textoHoras).
                AsignarSiguienteEslabon(textoDias).
                AsignarSiguienteEslabon(textoMeses);

            //Act
            textoMinutos.ProcesarSolicitud(textoMinutoDTO);

            //Assert
            Assert.AreEqual(cTextoEsperado, textoMinutoDTO.cTextoTransformado);
        }
    }
}
