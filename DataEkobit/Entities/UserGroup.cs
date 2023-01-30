using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEkobit.Entities
{
    [Table("UserGroup")]
    public class UserGroup
    {
        public long UserGroupId { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
      
        public long GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}
