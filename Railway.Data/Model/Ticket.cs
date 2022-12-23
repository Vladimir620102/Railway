using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class Ticket
    {
        public long Id { get; set; }
        public DateTime DepartureDate { get; set; }

        /// Станция назначения
        public int ArrivalStationId { get; set; }
        public string ArrivalStation { get; set; }

        /// <summary>
        /// Станция отправления
        /// </summary>
        public int DepartureStationId { get; set; }
        public string DepartureStation { get; set; }

        public int Train { get; set; }
        public int TrainId { get; set; }

        public int Vagon { get; set; }
        public int Place { get; set; }

        public string Passanger { get; set; }
    }
}
