using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataEkobit.Entities
{
    [Table("UserGroup")]
    public class UserGroup
    {
        public long UserGroupId { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public User User { get; set; }

        public long GroupId { get; set; }

        [ForeignKey("GroupId")]
        [JsonIgnore]
        public Group Group { get; set; }
    }
}
