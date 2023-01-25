using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEkobit.Models
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Capital { get; set; }
    }
}
