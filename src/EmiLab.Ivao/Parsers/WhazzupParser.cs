using System;
using System.Globalization;
using System.Threading.Tasks;
using EmiLab.Ivao.Models;

namespace EmiLab.Ivao.Parsers
{
    internal class WhazzupParser : IvaoParser
    {
        private readonly string _data;

        public new IvaoConnections Data { get; protected set; }


        #region CTORs

        public WhazzupParser(string rawData)
        {
            this._data = rawData;
        }
        #endregion


        /// <summary>
        /// Lancia il parser per il file whazzup dato
        /// </summary>
        public override void Parse()
        {
            //Last Update
            var lu = this._data.Substring(this._data.IndexOf(Consts.Ivao.LAST_UPDATE, StringComparison.InvariantCultureIgnoreCase) + 9, 14);

            var y = lu.Substring(0, 4);
            // ReSharper disable once InconsistentNaming
            var M = lu.Substring(4, 2);
            var d = lu.Substring(6, 2);

            var h = lu.Substring(8, 2);
            var m = lu.Substring(10, 2);
            var s = lu.Substring(12, 2);

            var dts = string.Format("{0}/{1}/{2} {3}:{4}:{5}", y, M, d, h, m, s);
            this.Data = new IvaoConnections(DateTime.ParseExact(dts, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));

            this.ParseFlightsList();
        }

        public override Task ParseAsync()
        {
            throw new NotImplementedException();
        }

        #region Parsing utilities

        // Parsa i dati dei voli
        private void ParseFlightsList()
        {
            var temp = this._data.Substring(this._data.IndexOf(Consts.Ivao.FLIGHTS_BEGIN, StringComparison.InvariantCultureIgnoreCase) + 8);
            var pl = temp.Substring(0, temp.IndexOf(Consts.Ivao.FLIGHTS_END, StringComparison.InvariantCultureIgnoreCase));


            var rows = pl.Split('\n');
            foreach (var f in rows)
            {
                if (f.Trim().Length > 0)
                {
                    var c = new Client(f);

                    switch (c.ConnType)
                    {
                        case ConnectionType.Pilot:
                            this.Data.Flights.Add(c);
                            break;
                        case ConnectionType.Atc:
                            this.Data.Atc.Add(c);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        #endregion
    }
}
