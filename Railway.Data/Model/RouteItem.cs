using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class RouteItem
    {
        public int Station { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }

    }
}
