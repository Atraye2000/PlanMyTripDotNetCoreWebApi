using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_appApi.context;
using my_appApi.models;

namespace my_appApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsBookingController : ControllerBase
    {
        private readonly AppDbContext _appContext;
        public FlightsBookingController(AppDbContext appDbContext)
        {
            _appContext = appDbContext;
        }

        [HttpPost("bookingDtls")]
        public void Post([FromBody] FlightBooking flightBooking)
        {
            _appContext.FlightsBooking.Add(flightBooking);
            _appContext.SaveChanges();
        }

    }
}
