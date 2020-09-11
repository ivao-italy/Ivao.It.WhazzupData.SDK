
using System.Text.RegularExpressions;

namespace EmiLab.Ivao
{
    static class Consts
    {
        internal static class Ivao
        {
            internal const string WAZZUP_URL = @"http://www.ivao.aero/whazzup/status.txt";
            internal const string URL_BEGIN = "url0=";
            internal const string METARS_BEGIN = "metar0=";
            internal const string TAFS_BEGIN = "taf0=";
            internal const string SHORTTAFS_BEGIN = "shorttaf0=";
            internal const string LAST_UPDATE = "UPDATE = ";
            internal const string FLIGHTS_BEGIN = "!CLIENTS";
            internal const string FLIGHTS_END = "!AIRPORTS";
        }


        internal static readonly Regex RGX_ICAO = new Regex(@"([A-Z]){4}");
        internal static readonly Regex RGX_MET_BEGIN = new Regex(@"([A-Z]){4} [0-9]{6}Z");
    }
}
