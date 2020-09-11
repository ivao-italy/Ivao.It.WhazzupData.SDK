using System.Linq;
using Xunit;

namespace EmiLab.Ivao.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetAndParse()
        {
            var ivaoData = new IvaoData();
            ivaoData.GetAndParse();

            var test = ivaoData.Clients.Flights.Single(t => t.Callsign == "AZA571");
        }
    }
}
