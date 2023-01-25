using System.ComponentModel.DataAnnotations.Schema;

namespace DataEkobit.Entities
{
    [Table("user")]
    public class User
    {
        
        public long UserId { get; set; }  
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string? Password { get; set; }
        public string? Nickname { get; set; }
        public Country? Country { get; set; }  //ili samo da stavim da bude CountryId jer se kod updejtanja i dodavanja novog usera trazi da se unesu svi podaci za drzavu
        //public long? CountryId { get; set; }
    }
}