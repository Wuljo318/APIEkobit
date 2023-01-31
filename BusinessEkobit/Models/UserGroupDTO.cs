namespace BusinessEkobit.Models
{
    public class UserGroupDTO
    {
        public long UserGroupId { get; set; }

        public long UserId { get; set; }

        public UserDTO UserDTO { get; set; }

        public long GroupId { get; set; }

        public GroupDTO GroupDTO { get; set; }
    }
}
