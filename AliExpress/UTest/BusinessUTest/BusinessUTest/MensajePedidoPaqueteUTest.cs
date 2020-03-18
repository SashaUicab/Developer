using Business;
using Entities;
using Interfaces.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BusinessUTest
{
    /// <summary>
    /// Summary description for ObtenerMensajePedidoPaqueteUTest
    /// </summary>
    [TestClass]
    public class MensajePedidoPaqueteUTest
    {
        [TestMethod]
        public void ObtenerMensajePedidoPaquete_PedidoDHLAereo100KM_MensajeConInformacionPedidoCorrecto()
        {
            //Arrange.
            PedidoDTO pedido = CrearEntidadPedidoDTOPrueba();
            decimal dMinutosEntrega = 172800M;
            decimal dCostoEnvio = 6829800;
            List<string> lstMensajeEsperado = new List<string>();
            string cMensajeEsperado = "Tu paquete ha salido de Pekin, China y llegará a Cancún, México dentro de 4 meses y tendrá un costo de $6,829,800(Cualquier reclamación con DHL).";
            lstMensajeEsperado.Add(cMensajeEsperado);
            var docConjugacionesMensajeFechaEntrega = new Mock<IConjugacionesMensajeFechaEntrega>();
            docConjugacionesMensajeFechaEntrega.Setup(doc => doc.ObtenerConjugacionSalida(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("ha salido"); docConjugacionesMensajeFechaEntrega.Setup(doc => doc.ObtenerConjugacionLlegada(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("llegará");
            docConjugacionesMensajeFechaEntrega.Setup(doc => doc.ObtenerConjugacionLapsoTiempo(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("dentro de");
            docConjugacionesMensajeFechaEntrega.Setup(doc => doc.ObtenerConjugacionTener(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns("tendrá");
            DateTime dtFechaEntrega = new DateTime(2020, 5, 12, 14, 10, 12);
            DateTime dtFechaActual = new DateTime(2020, 1, 23, 14, 00, 00);
            var docCadenaTiempoEntrega = new Mock<ICadenaTiempoEntrega>();
            docCadenaTiempoEntrega.Setup(doc => doc.ObtenerCadenaTiempoEntrega(It.IsAny<decimal>())).Returns("4 meses");

            var docCadenaCostoEnvio = new Mock<ICadenaCostoEnvio>();
            docCadenaCostoEnvio.Setup(doc => doc.ObtenerCadenaCostoEnvio(It.IsAny<decimal>())).Returns("$6,829,800");
            //Act.
            MensajePedidoPaquete SUT = new MensajePedidoPaquete(docConjugacionesMensajeFechaEntrega.Object, docCadenaTiempoEntrega.Object, docCadenaCostoEnvio.Object);
            string cMensajeCorrecto = SUT.ObtenerMensajePedidoPaquete(pedido, dtFechaEntrega, dtFechaActual, dMinutosEntrega, dCostoEnvio);

            //Assert.
            Assert.AreEqual(cMensajeEsperado, cMensajeCorrecto);
        }

        private PedidoDTO CrearEntidadPedidoDTOPrueba()
        {
            //Tu paquete[Expresión1] de[Origen] y [Expresión2] a[Destino]
            //[Expresión3][Rango de Tiempo] y[Expresión4] un costo de[Costo
            //de envío](Cualquier reclamación con[Paquetería]).
    
            PedidoDTO pedido = new PedidoDTO();
            pedido.dDistancia = 100M;
            pedido.cNombrePaqueteria = "DHL";
            pedido.cNombreMedioTransporte = "Aéreo";
            pedido.dtFechaPedido = new DateTime(2020, 1, 23, 14, 0, 0);
            pedido.cNombrePaisOrigen = "China";
            pedido.cNombreCiudadOrigen = "Pekin";
            pedido.cNombrePaisDestino = "México";
            pedido.cNombreCiudadDestino = "Cancún";
            return pedido;
        }
    }
}
