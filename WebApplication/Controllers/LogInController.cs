using System;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                User user = await _data.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}