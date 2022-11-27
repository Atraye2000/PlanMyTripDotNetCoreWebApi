using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_appApi.context;
using my_appApi.models;

namespace my_appApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookingController : ControllerBase
    {
        private readonly AppDbContext _appContext;
        public bookingController(AppDbContext appDbContext)
        {
            _appContext = appDbContext;
        }

        [HttpPost("Packagebooking")]
        public async Task<IActionResult> Packagebooking([FromBody] booking bookingObj)
        {
            if (bookingObj == null)
                return BadRequest();
            await _appContext.Bookings.AddAsync(bookingObj);
            await _appContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Booked !"
            });
        }
    }
}
