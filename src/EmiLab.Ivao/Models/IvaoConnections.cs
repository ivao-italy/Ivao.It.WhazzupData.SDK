using System;
using System.Collections.Generic;

namespace EmiLab.Ivao.Models
{
    public class IvaoConnections
    {
        public IvaoConnections(DateTime lastUpdate)
        {
            this.LastUpdate = lastUpdate;
            this.Flights = new List<Client>();
            this.Atc = new List<Client>();
        }

        public DateTime LastUpdate { get; private set; }
        public List<Client> Flights { get; internal set; }
        public List<Client> Atc { get; internal set; }
    }
}