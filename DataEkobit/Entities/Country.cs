using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEkobit.Entities
{
    [Table("country")]
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string? Continent { get; set; }
        public string? CountryCode { get; set; }
        public string? Capital { get; set; }
        public List<User> Users { get; set; }
    }
}
