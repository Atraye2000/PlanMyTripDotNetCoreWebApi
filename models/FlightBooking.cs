using System.ComponentModel.DataAnnotations;

namespace my_appApi.models
{
    public class FlightBooking
    {
        [Key]
        public int bid { get; set; }
       
        public int id { get; set; }
        public int fid { get; set; }
        public string currentDate { get; set; }

        public ICollection<Flight>Flights { get; set; }
    }
}
