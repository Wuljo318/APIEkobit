using DataEkobit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEkobit.Models
{
    public class GroupDTO
    {
        public long GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserGroup> UserGroups { get; set; }
    }
}
