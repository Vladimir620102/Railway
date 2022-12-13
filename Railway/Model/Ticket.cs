using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Model
{
    internal class Ticket
    {
        public long Id { get; set; }
        public DateTime ArrivalDate { get; set; }
       
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }

        public string Train { get; set; }
        public string Vagon { get; set; }
        public string Place { get; set; }
    }
}
