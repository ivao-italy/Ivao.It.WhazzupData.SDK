using System.Collections.Generic;
using System.Linq;
using EmiLab.Ivao.Helpers;
using EmiLab.Ivao.Models;
using EmiLab.Ivao.Parsers;

namespace EmiLab.Ivao
{
    public class IvaoData
    {
        public IvaoConnections Clients { get; private set; }

        /// <summary>
        /// Instanzia i models con i dati parsati da IVAO
        /// </summary>
        /// <returns></returns>
        public void GetAndParse()
        {
            //Recupero l'url dei piloti
            var data = WebAccessHelper.Get();

            //Parso i dati
            var cparser = new WhazzupParser(data);
            cparser.Parse();
            this.Clients = cparser.Data;
        }



        private static string GetUrlFromWhatsApp(IEnumerable<string> hpts, string urkMarker)
        {
            return hpts.Single(s => s.StartsWith(urkMarker)).Remove(0, urkMarker.Length);
        }
    }
}
