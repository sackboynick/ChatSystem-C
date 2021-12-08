using System;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("UserServer")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _data;

        public UserController([FromServices] IUserRepo data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int userId)
        {
            try
            {
                User user = _data.GetUser(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("{username}/{friendToAdd}/{closeFriend}")]
        public async Task<ActionResult> AddFriend([FromRoute] string username,[FromRoute] string friendToAdd,[FromRoute] bool closeFriend)
        {
            try
            {
                _data.AddFriend(username,new Friendship(friendToAdd,closeFriend));
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}