using System;
using System.Threading.Tasks;
using DataAccess.Data;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _data;

        public UserController([FromServices] IUserRepo data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] string username)
        {
            try
            {
                User user = _data.GetUser(username);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> AddFriend([FromRoute] string username,[FromBody] Friendship friendship)

        {
            try
            {
                _data.AddFriend(username, friendship);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}