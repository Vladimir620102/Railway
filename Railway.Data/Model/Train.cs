using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class Train
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int DepartureStationId { get; set; }
        public string DepartureStationName { get; set; }
        public int ArrivalStationId { get; set; }
        public string ArrivalStationName { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int RouteId { get; set; }

    }
}
