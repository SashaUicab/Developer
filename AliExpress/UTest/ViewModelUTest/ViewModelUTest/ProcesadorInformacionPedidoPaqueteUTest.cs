using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using ViewModel;
using Moq;
using Interfaces.Business;

namespace ViewModelUTest
{
    /// <summary>
    /// Summary description for ProcesadorInformacionPaqueteUTest
    /// </summary>
    [TestClass]
    public class ProcesadorInformacionPedidoPaqueteUTest
    {
        [TestMethod]
        public void ObtenerInformacionPedidoPaquete_PedidoDHLAereo100KM_MensajeConInformacionPedido()
        {
            //Arrange
            PedidoDTO pedido = CrearEntidadPedidoDTOPrueba();
            DateTime dtFechaActual = DateTime.Now;

            string cMensajeEsperado = "Tu paquete ha salido de Pekin, China y llegará a Cancún, México dentro de 4 meses y tendrá un costo de $6,829,800(Cualquier reclamación con DHL).";

            var docMensajePedidoPaquete = new Mock<IMensajePedidoPaquete>();
            docMensajePedidoPaquete.Setup(doc => doc.ObtenerMensajePedidoPaquete(It.IsAny<PedidoDTO>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(cMensajeEsperado);
            var docTiempoEntrega = new Mock<ITiempoEntrega>();
            docTiempoEntrega.Setup(doc => doc.ObtenerTiempoEntrega(It.IsAny<decimal>(), It.IsAny<EnumMedioTransporte>())).Returns(172800M);

            var docFechaEntrega = new Mock<IFechaEntrega>();
            docFechaEntrega.Setup(doc => doc.ObtenerFechaEntrega(It.IsAny<DateTime>(), It.IsAny<int>())).Returns(new DateTime(2020, 1, 23, 14, 0, 0));

            var docCostoEnvio = new Mock<ICostoEnvio>();
            docCostoEnvio.Setup(doc => doc.ObtenerCostoEnvio(It.IsAny<EnumEmpresa>(), It.IsAny<DateTime>(), It.IsAny<decimal>())).Returns(6829800M);
            //Act
            ProcesadorInformacionPedidoPaquete SUT = new ProcesadorInformacionPedidoPaquete(docMensajePedidoPaquete.Object, docTiempoEntrega.Object, docFechaEntrega.Object, docCostoEnvio.Object);
            string cMensajeInformacion = SUT.ObtenerInformacionPedidoPaquete(pedido, dtFechaActual);

            //Assert
            Assert.AreEqual(cMensajeEsperado, cMensajeInformacion);
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
