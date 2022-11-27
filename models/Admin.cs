using System.ComponentModel.DataAnnotations;

namespace my_appApi.models
{
    public class Admin
    {
        [Key]
        public int id { get; set; }

        public string placeName { get; set; }
        public string details { get; set; }
        public string rating { get; set; }
        public string price { get; set; }
    }
}
