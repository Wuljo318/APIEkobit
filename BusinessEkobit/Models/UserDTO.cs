namespace BusinessEkobit.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public CountryDTO CountryDTO { get; set; }
        public int CountryId { get; set; }
        public GroupDTO GroupDTO { get; set; }
        public int GroupId { get; set; }

    }
}
