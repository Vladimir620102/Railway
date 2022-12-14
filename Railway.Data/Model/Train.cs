using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class Train
    {
        int Id { get; set; }
        public int Number { get; set; }
        public int from_station_id { get; set; }
        public int to_station_id { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }

    }
}
