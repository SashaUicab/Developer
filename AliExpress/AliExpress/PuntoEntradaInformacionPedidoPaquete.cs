using AliExpress.ConfiguracionDependencias;
using Business;
using Business.Factory;
using Entities;
using Interfaces.Business;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace AliExpress
{
    public class PuntoEntradaInformacionPedidoPaquete
    {
        static void Main(string[] args)
        {
            // DateTime dtFechaActual = DateTime.Now;
            List<PedidoDTO> lstPedidoDTO = new List<PedidoDTO>();
            lstPedidoDTO = CrearListaEntidadPedidoDTOPrueba();
            List<string> lstInformacionPedido=ObtenerMensajesPedido(lstPedidoDTO);
            foreach(string cMensaje in lstInformacionPedido)
            {
                Console.WriteLine(cMensaje);
            }
        }

        private static List<string> ObtenerMensajesPedido(List<PedidoDTO> _lstPedidoDTO)
        {
            DateTime dtFechaActual = new DateTime(2020, 1, 23, 14, 0, 0);
            var docContainer = Container.For<DI_Dependencias>();
            TiempoRepartoFactory tiempoRepartoFactory = new TiempoRepartoFactory(docContainer);
            TiempoTrasladoFactory tiempoTrasladoFactory = new TiempoTrasladoFactory();
            MensajePedidoPaquete mensajePedidoPaquete = ObtenerInstanciaMensajePedidoPaquete();
            CostoEnvioFactory costoEnvioFactory = new CostoEnvioFactory(docContainer);
            List<string> lstInformacionPedido = new List<string>();
      
            foreach (PedidoDTO pedido in _lstPedidoDTO)
            {
                ITiempoReparto tiempoReparto = tiempoRepartoFactory.CrearInstancia(pedido.enumEmpresa);
                ITiempoTraslado tiempoTraslado = tiempoTrasladoFactory.CrearInstancia(pedido.enumMedioTransporte);
                ITiempoEntrega tiempoEntrega = new TiempoEntrega(tiempoTraslado, tiempoReparto);
                IFechaEntrega fechaEntrega = new FechaEntrega();
                ICostoEnvio costoEnvio = costoEnvioFactory.CrearInstancia(pedido.enumMedioTransporte, pedido.cIdentificadorEmpresa);
                ProcesadorInformacionPedidoPaquete procesadorInformacionPedidoPaquete = new ProcesadorInformacionPedidoPaquete(mensajePedidoPaquete, tiempoEntrega, fechaEntrega, costoEnvio);
                lstInformacionPedido.Add(procesadorInformacionPedidoPaquete.ObtenerInformacionPedidoPaquete(pedido, dtFechaActual));
            }
            return lstInformacionPedido;
        }

        private static MensajePedidoPaquete ObtenerInstanciaMensajePedidoPaquete()
        {
            ConjugacionesMensajeFechaEntrega conjugacionesMensajeFechaEntrega = new ConjugacionesMensajeFechaEntrega();
            CadenaTiempoEntrega cadenaTiempoEntrega = new CadenaTiempoEntrega();
            ICadenaCostoEnvio cadenaCostoEnvio = new CadenaCostoEnvioPesos();
            MensajePedidoPaquete mensajePedidoPaquete = new MensajePedidoPaquete(conjugacionesMensajeFechaEntrega, cadenaTiempoEntrega, cadenaCostoEnvio);
            return mensajePedidoPaquete;
        }

        private static List<PedidoDTO> CrearListaEntidadPedidoDTOPrueba()
        {
            //Tu paquete[Expresión1] de[Origen] y [Expresión2] a[Destino]
            //[Expresión3][Rango de Tiempo] y[Expresión4] un costo de[Costo
            //de envío](Cualquier reclamación con[Paquetería]).
            List<PedidoDTO> lstPedidoDTO = new List<PedidoDTO>();
            PedidoDTO pedido = new PedidoDTO();
            pedido.dDistancia = 446400M;
            pedido.cNombrePaqueteria = "DHL";
            pedido.cNombreMedioTransporte = "Aéreo";
            pedido.dtFechaPedido = new DateTime(2020, 1, 23, 8, 0, 0);
            pedido.cNombrePaisOrigen = "China";
            pedido.cNombreCiudadOrigen = "Pekin";
            pedido.cNombrePaisDestino = "México";
            pedido.cNombreCiudadDestino = "Cancún";
            pedido.cIdentificadorEmpresa = "DHL";
            pedido.enumEmpresa = EnumEmpresa.DHL;
            pedido.enumMedioTransporte = EnumMedioTransporte.Aereo;
            lstPedidoDTO.Add(pedido);
            return lstPedidoDTO;
        }
    }
}
