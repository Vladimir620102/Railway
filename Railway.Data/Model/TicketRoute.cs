using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class TicketRoute
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int From_station_id { get; set; }
        public string DepartureName { get; set; }
        public int To_station_id { get; set; }
        public string ArrivalName { get; set; }
    }
}
