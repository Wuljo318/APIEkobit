using DataEkobit.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEkobit.Models
{
    public class UserGroupDTO
    {
        public long UserGroupId { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long GroupId { get; set; }

        public Group Group { get; set; }
    }
}
