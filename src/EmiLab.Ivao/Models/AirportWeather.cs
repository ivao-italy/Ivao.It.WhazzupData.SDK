

namespace EmiLab.Ivao.Models
{
    public class AirportWeather
    {
        public string ICAO { get; private set; }

        public string Metar { get; private set; }

        public string Taf { get; private set; }


        #region Costruttori

        internal AirportWeather(string ICAO, string metar)
        {
            this.ICAO = ICAO;
            this.Metar = metar;
        }

        internal AirportWeather(string ICAO, string metar, string taf)
            : this(ICAO, metar)
        {
            this.Taf = taf;
        }

        #endregion

        #region Object Overridings : Equality Comparison

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            // Implementazione custom di ugualianza
            return (this.ICAO == ((AirportWeather)obj).ICAO);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // Implemento il mio hashcode:
            // Sommo i codes dei valori di istanza e li moltiplico per un numero primo.

            int hashcode = this.ICAO.GetHashCode() * 17 + this.Metar.GetHashCode() * 17;
            hashcode = (this.Taf != null) ? this.Taf.GetHashCode() * 17 : hashcode;
            return hashcode;
        }

        #endregion
    }
}
