using System;
using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessUTest
{
    [TestClass]
    public class FechaEntregaUTest
    {
        [TestMethod]
        public void ObtenerFechaEntrega_TiempoDeEntrega4Meses_FechadeEntregaDentro4Meses()
        {
            //Arrange
            DateTime dtFechaPedido = new DateTime(2020, 1, 23, 14, 0, 0);
            DateTime dtFechaEntregaEsperado = new DateTime(2020, 5, 22, 14, 0, 0);
            int iMinutos = 172800;
            FechaEntrega SUT = new FechaEntrega();
           
            //Act
            DateTime dFechaEntrega = SUT.ObtenerFechaEntrega(dtFechaPedido, iMinutos);

            //Assert
            Assert.AreEqual(dtFechaEntregaEsperado, dFechaEntrega);
        }
    }
}
