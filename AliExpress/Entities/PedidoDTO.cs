using System;

namespace Entities
{
    public class PedidoDTO
    {
        public decimal dDistancia { get; set; }
        public string cNombrePaqueteria { get; set; }
        public string cNombreMedioTransporte { get; set; }
        public DateTime dtFechaPedido { get; set; }
        public string cNombrePaisOrigen { get; set; }
        public string cNombreCiudadOrigen { get; set; }
        public string cNombrePaisDestino { get; set; }
        public string cNombreCiudadDestino { get; set; }
        public EnumMedioTransporte enumMedioTransporte { get; set; }
        public EnumEmpresa enumEmpresa { get; set; }

        public string cIdentificadorEmpresa {get; set;}
    }
}

