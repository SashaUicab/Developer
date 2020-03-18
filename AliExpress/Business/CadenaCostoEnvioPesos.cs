using Interfaces.Business;
using System;
using System.Globalization;

namespace Business
{
    public class CadenaCostoEnvioPesos : ICadenaCostoEnvio
    {
        public string ObtenerCadenaCostoEnvio(decimal _dCosto)
        {
            string cDeCadenaCostoEnvio = FormatearDecimales(_dCosto);
            return $"${cDeCadenaCostoEnvio}";
        }

        private string FormatearDecimales(decimal _dCosto)
        {
            _dCosto.ToString("#,#", CultureInfo.InvariantCulture);
            string cDeCadenaCostoEnvio = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", _dCosto);
            return cDeCadenaCostoEnvio;
        }
    }
}
