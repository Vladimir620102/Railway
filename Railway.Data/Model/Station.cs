using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class Station
    {
         public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

    }
}
