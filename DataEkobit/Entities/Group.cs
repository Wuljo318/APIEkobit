namespace DataEkobit.Entities
{
    public class Group
    {
        public long GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserGroup> UserGroups { get; set; }
    }
}
