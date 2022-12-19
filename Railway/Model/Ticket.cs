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
       
        /// Станция назначения
        public string ArrivalStation { get; set; }

        /// <summary>
        /// Станция отправления
        /// </summary>
        public string DepartureStation { get; set; }

        public string Train { get; set; }
        public string Vagon { get; set; }
        public string Place { get; set; }
    }
}
