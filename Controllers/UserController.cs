using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_appApi.context;
using my_appApi.helpers;
using my_appApi.models;
using System.Text;
using System.Text.RegularExpressions;

namespace my_appApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appContext;
        public UserController(AppDbContext appDbContext)
        {
            _appContext = appDbContext;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authentication([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _appContext.Users
                .FirstOrDefaultAsync(x => x.UserName == userObj.UserName);
            if (user == null)
                return NotFound(new { Message = "User Not Found" });

            if(!PasswordHasher.VerifyPassword(userObj.password,user.password))
            {
                return BadRequest(new { Message = "Password is Incorrect"});
            }
            return Ok(userObj);
            /*return Ok(new
            {
                 Message = "Login Success !"        
            });*/
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userobj)
        {
            if (userobj == null)
                return BadRequest();

            //check userName
            if(await CheckUserNameExistAsysnc(userobj.UserName))
                return BadRequest(new {message ="User Name already exist !"});

            //check email
            if (await CheckEmailExistAsysnc(userobj.Email))
                return BadRequest(new { message = "This email is already exist !" });

            //check passwordStrength
            var pass = CheckPasswordStreangth(userobj.password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });


            userobj.password = PasswordHasher.HashPassword(userobj.password);
            userobj.Role = "User";
            userobj.Token = "";
            await _appContext.Users.AddAsync(userobj);
            await _appContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered !"
            });
        }

        private Task<bool> CheckUserNameExistAsysnc(String username)
             => _appContext.Users.AnyAsync(x => x.UserName == username);

        private Task<bool> CheckEmailExistAsysnc(String email)
            => _appContext.Users.AnyAsync(x => x.Email == email);

        private string CheckPasswordStreangth(string password)
        {
            StringBuilder sb= new StringBuilder();
            if(password.Length < 8)
                sb.Append("Minimum password length should be 8" +Environment.NewLine);
            if(!(Regex.IsMatch(password, "[a-z]")&& Regex.IsMatch(password, "[A-Z]")
                && Regex.IsMatch(password, "[0-9]")))
                sb.Append("password should be Alphanumeric"+ Environment.NewLine);
            if(!Regex.IsMatch(password,"[<,>,@,!,#,$,%,^,&,*,(,),?,//[,\\],},{,+,=,/,_,-,']"))
                sb.Append("password should be contain special character"+Environment.NewLine);
            return sb.ToString();   
        }

    }
}
