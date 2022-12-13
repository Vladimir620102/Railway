using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Data.Model
{
    public class City
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public string Name { get; set; }
    }
}
