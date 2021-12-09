using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[FriendshipServer]")]
    public class FriendshipController : Controller
    {
        private readonly IData _data;

        public FriendshipController([FromServices] IData data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{friendshipId}")]
        public async Task<ActionResult<List<Friendship>>> GetFriendships([FromRoute] int? usernameId)
        {
            try
            {
                if (usernameId != null)
                {
                    List<Friendship> friendships = _data.GetAllFriendsOfUser(usernameId.Value);

                    return Ok(friendships);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

            return null;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateFriendship([FromBody] Friendship friendship)
        {
            try
            {
                await _data.UpdateFriendship(friendship);
                
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
                    await _data.RemoveFriend(friendshipId.Value);

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