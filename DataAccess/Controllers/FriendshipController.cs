using System;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendshipController : Controller
    {
        private readonly IDataRepo _data;

        public FriendshipController([FromServices] IDataRepo data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{friendshipId}")]
        public async Task<ActionResult<Friendship>> GetFriendship([FromRoute] int? friendshipId)
        {
            try
            {
                if (friendshipId != null)
                {
                    Friendship friendship = _data.GetFriendship(friendshipId.Value);

                    return Ok(friendship);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

            return null;
        }

        [HttpPost]
        public async Task<ActionResult> AddFriendship([FromBody] Friendship friendship)
        {
            try
            {
                _data.AddFriendship(friendship);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateFriendship([FromBody] Friendship friendship)
        {
            try
            {
                _data.UpdateFriendship(friendship);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{friendshipId}")]
        public async Task<ActionResult<Friendship>> RemoveFriend([FromRoute] int? friendshipId)
        {
            try
            {
                if (friendshipId != null)
                {
                    _data.RemoveFriend(friendshipId.Value);

                    return Ok();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

            return null;
        }
    }
}