using System;
using System.Threading.Tasks;
using DataAccess.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
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
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username,[FromQuery] string password )
        {
            try
            {
                User user = _data.ValidateUser(username, password);
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