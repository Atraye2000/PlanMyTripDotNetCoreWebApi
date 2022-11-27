using System.ComponentModel.DataAnnotations;

namespace my_appApi.models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String password { get; set; }
        public String Token { get; set; }
        public String Role { get; set; }

       //public ICollection<booking> Bookings { get; set; }

    }
}
