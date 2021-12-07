using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]Server")]
    public class LogInController : ControllerBase
    {
        private readonly IUserService _data;

        public LogInController([FromServices] IUserService data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{username}/{password}")]
        public async Task<ActionResult<User>> ValidateUser([FromRoute] string username,[FromRoute] string password )
        {
            try
            {
                User user = _data.ValidateUser(username, password).Result;
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            try
            {
                await _data.RegisterUser(user);
                
                return Ok(user);
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}