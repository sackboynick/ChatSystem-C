using System;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("UserServer")]
    public class UserController : ControllerBase
    {
        private readonly IData _data;

        public UserController([FromServices] IData data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int userId)
        {
            try
            {
                User user = _data.GetUser(userId).Result;
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                await _data.UpdateUser(user);
                return Ok();
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
                await _data.AddFriend(username,friendToAdd,closeFriend);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}