using System.ComponentModel.DataAnnotations;

namespace my_appApi.models
{
    public class Flight
    {
        [Key]
        public int fid { get; set; }
        public string fname { get; set; }
        public string source { get; set; }

        public string destination  { get; set; }

       public string departureTime { get; set; }

        public string arrivalTime { get; set; }

        public string date { get; set; }

        public string price { get; set; }

        public int seatAvl { get; set; }

    }
}
