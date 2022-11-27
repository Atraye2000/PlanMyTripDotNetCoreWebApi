using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_appApi.models
{
    public class booking
    {
        [Key]
        public int bookingid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phno { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        public string checkInDate { get; set; }
        public string place{ get; set; }

        //foreign key

        //[Display (Name ="User")]
       // public virtual int id { get; set; }
        //[ForeignKey ("id")]
        //public virtual User Users { get; set; }



    }
}
