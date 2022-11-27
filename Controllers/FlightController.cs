using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using my_appApi.context;
using my_appApi.models;
using System.Security.Cryptography.X509Certificates;

namespace my_appApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly AppDbContext _appContext;
        

        public FlightController(AppDbContext appDbContext)
        {
            _appContext = appDbContext;
        }
        //Add get request
       
        [HttpPost("getfdata")]
        public async Task<IActionResult> GetFlights([FromBody] Flight flightObj)
        {
            if (flightObj == null)
                return BadRequest();

            var flight = await _appContext.Flights
                .FirstOrDefaultAsync(x => x.date == flightObj.date && x.arrivalTime == flightObj.arrivalTime);
            if (flight == null)
                return NotFound(new { Message = "User Not Found" });
            return Ok(flightObj);
        }

        [HttpGet("Fname")]
        public async Task<ActionResult<Flight>> GetFlight(string fname)
        {
            var Flight = await _appContext.Flights.FindAsync(fname);  
            if(Flight == null)
                return NotFound();
            return Flight;
        }

        [HttpGet("getflight")]

        public async Task<ActionResult<FlightPayload>> GetFlight([FromQuery] QueryStringParameters qsParameters)
        {
            IQueryable<Flight> returnFlights = _appContext.Flights.OrderBy(on => on.fid);
            List<Flight> list = await returnFlights.ToListAsync();

            


            return new FlightPayload(list);
        }



        }
}
