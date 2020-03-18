using AliExpress.ConfiguracionDependencias;
using Business;
using Business.Factory;
using Entities;
using Interfaces.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace BusinessUTest.Factory
{
    [TestClass]
    public class TiempoRepartoFactoryUTest
    {
        [TestMethod]
        public void CrearInstancia_ObtenerInstanciaDHL_InsanciaDeTipoTiempoRepartoDHL()
        {
            //Arrange
            //var docContainer = new Mock<IContainer>();
            //docContainer.Setup(doc => doc.GetInstance<ITiempoReparto>(It.IsAny<string>())).Returns(new TiempoRepartoDHL());
            var docContainer = Container.For<DI_Dependencias>();//Según lo que comentó Pedrusco(pruebas amigables) se puede hacer así también.
            TiempoRepartoFactory SUT = new TiempoRepartoFactory(docContainer);
            //Act
            ITiempoReparto tiempoRepartoDHL = SUT.CrearInstancia(EnumEmpresa.DHL);
            //Assert
            Assert.IsInstanceOfType(tiempoRepartoDHL, typeof(TiempoRepartoDHL));
        }
    }
}
