using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_appApi.context;
using my_appApi.models;

namespace my_appApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _appContext;

        public AdminController(AppDbContext appContext)
        {
            _appContext = appContext;
        }


        [HttpGet]
        public async Task<ActionResult<AdminPayload>> GetAdmin([FromQuery] QueryStringParameters qsParameters)
        {
            IQueryable<Admin> returnAdmins = _appContext.Admins.OrderBy(on => on.id);
            List<Admin> list = await returnAdmins.ToListAsync();
            return new AdminPayload(list);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var Admin = await _appContext.Admins.FindAsync(id);
            if (Admin == null)
                return NotFound();
            return Admin;
        }

        [HttpPost("post")]
        public void Post([FromBody] Admin admin)
        {
            _appContext.Admins.Add(admin);
            _appContext.SaveChanges();
        }

        //Add Put Request for Update
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Admin adminObj)
        {
            var admin = _appContext.Admins.Find(id);
            if (adminObj != null)
            {
                admin.placeName = adminObj.placeName;
                admin.details = adminObj.details;
                admin.rating = adminObj.rating;
                admin.price = adminObj.price;
                _appContext.SaveChanges();

            }

        }

        //Add Delete Request

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var admin = _appContext.Admins.Find(id);
            _appContext.Admins.Remove(admin);
            _appContext.SaveChanges();
        }

    }
}

    

