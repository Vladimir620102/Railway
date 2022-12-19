using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class Route
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public int ArrivalStationId { get; set; }
        public string ArrivalStationName { get; set; }
        public int DepartureStationId { get; set; }
        public string DepartureStationName { get; set; }
        public string Name { get => $"Поезд №{Number}  {DepartureStationName} - {ArrivalStationName}"; }
        List<RouteItem> _items= new List<RouteItem>();
        public List<RouteItem> Items { get => _items; }
    }
}
