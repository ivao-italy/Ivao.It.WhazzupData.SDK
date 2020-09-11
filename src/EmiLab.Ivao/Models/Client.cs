using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace EmiLab.Ivao.Models
{

    [DebuggerDisplay("{Display}")]
    public class Client
    {
        //Raw data
        private readonly string _data;

        #region ITEM DATA

        //conncection data
        public string Callsign { get; internal set; }
        public string Vid { get; internal set; }
        public string Name { get; internal set; }
        public ConnectionType ConnType { get; internal set; }
        public string Server { get; internal set; }
        public DateTime ConnectionTime { get; internal set; }

        //tracker data
        public float Lat { get; internal set; }
        public float Lng { get; internal set; }
        public string Alt { get; internal set; }
        public int Gs { get; internal set; }
        public string Squawk { get; internal set; }
        public string Heading { get; internal set; }

        //FPL data
        public string Aircraft { get; internal set; }
        public string AircraftCat { get; internal set; }
        public string Equipment { get; internal set; }
        public string Transponder { get; internal set; }


        public string Rules { get; internal set; }
        public string Speed { get; internal set; }
        public string Rfl { get; internal set; }
        public string Dep { get; internal set; }
        public string Arr { get; internal set; }
        // ReSharper disable once InconsistentNaming
        public string ETOD { get; internal set; }
        // ReSharper disable once InconsistentNaming
        public string ETE { get; internal set; }
        public string Endurance { get; internal set; }
        public string AltArr { get; internal set; }
        public string Remarks { get; internal set; }
        public string Route { get; internal set; }
        // ReSharper disable once InconsistentNaming
        public int POB { get; internal set; }
        public string Type { get; internal set; }
        public bool OnGround { get; internal set; }

        public string Display
        {
            get
            {
                return String.Format("{0} ({4}) {1} - {2} {3} ", this.Callsign, this.Dep, this.Arr, this.Aircraft, this.Vid);
            }
        }

        #endregion

        #region CTORs

        public Client()
        {
        }

        public Client(string rawdata)
        {
            this._data = rawdata;

            this.ParseData();
        }

        #endregion


        //Parsa i dati del piano di volo e quelli di posizione
        private void ParseData()
        {
            var exp = this._data.Split(':');

            if (exp.Any())
            {
                this.Callsign = exp[0];
                this.Vid = exp[1];

                if (!string.IsNullOrEmpty(exp[2]))
                {
                    //separo homebase e nome
                    this.Name = exp[2];
                }

                this.ConnType = String.Equals(exp[3], "PILOT", StringComparison.InvariantCultureIgnoreCase) ? ConnectionType.Pilot : ConnectionType.Atc;
                if (this.ConnType == ConnectionType.Pilot)
                {
                    this.ConnectionTime = DateTime.ParseExact(exp[37], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                }

                this.Lat = float.TryParse(exp[5], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out var lat) ? lat : 0;

                this.Lng = float.TryParse(exp[6], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out var lon) ? lon : 0;

                this.Alt = exp[7];

                this.Gs = int.TryParse(exp[8], out var gs) ? gs : 0;

                this.ParseAircraft(exp[9]);


                this.Speed = exp[10];
                this.Dep = exp[11];
                this.Arr = exp[13];
                this.Rfl = exp[12];
                this.Server = exp[14];
                this.Squawk = exp[17];
                this.Rules = exp[21];


                //Se le ore mancano di uno 0 lo aggiungo in testa per poi formattare il time come dovuto.
                if (exp[22].Length > 0)
                {
                    string tempEtod = exp[22].PadLeft(4, '0');
                    this.ETOD = $"{tempEtod.Substring(0, 2)}:{tempEtod.Substring(2, 2)}";
                }

                if (exp[24].Length > 0 && exp[25].Length > 0)
                {
                    if (exp[24].Length == 1)
                        exp[24] = "0" + exp[24];
                    if (exp[25].Length == 1)
                        exp[25] = "0" + exp[25];

                    this.ETE = $"{exp[24]}:{exp[25]}";
                }

                if (exp[26].Length > 0 && exp[25].Length > 0)
                {
                    if (exp[26].Length == 1)
                        exp[26] = "0" + exp[26];
                    if (exp[27].Length == 1)
                        exp[27] = "0" + exp[27];

                    this.Endurance = $"{exp[26]}:{exp[27]}";
                }

                this.AltArr = exp[28];
                this.Remarks = exp[29];
                this.Route = exp[30];
                this.Type = exp[43];

                if (int.TryParse(exp[44], out var temp))
                    this.POB = temp;

                this.Heading = exp[45];

                bool.TryParse(exp[46], out var ab);
                this.OnGround = ab;
            }

        }

        // Parsa i dati dell'aeromobile
        private void ParseAircraft(string acRawData)
        {
            if (acRawData.Length > 0)
            {
                var exp = acRawData.Split('/');
                if (exp.Any())
                {
                    this.Aircraft = exp[1];
                    this.Transponder = exp[3];

                    var catEq = exp[2].Split('-');
                    if (catEq.Any())
                    {
                        this.AircraftCat = catEq[0];
                        this.Equipment = catEq[1];
                    }
                }
            }
        }

    }
}
