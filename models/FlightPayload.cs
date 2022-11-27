namespace my_appApi.models
{
    public class FlightPayload
    {
        private List<Flight> list;

        public List<Flight> Flights { get; set; }

        public int Count { get; set; }

        public FlightPayload(List<Flight> Flights)
        {
            this.Flights = Flights;
           // this.Count = Count;
        }

       
    }
}
