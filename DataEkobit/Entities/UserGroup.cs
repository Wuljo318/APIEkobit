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
    [PrimaryKey("UserGroupId")]
    public class UserGroup
    {
        public long UserGroupId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
