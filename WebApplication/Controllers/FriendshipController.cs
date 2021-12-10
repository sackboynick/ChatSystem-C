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
    [Route("FriendshipServer")]
    public class FriendshipController : Controller
    {
        private readonly IData _data;

        public FriendshipController([FromServices] IData data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("/FriendsOf/{userId}")]
        public async Task<ActionResult<List<Friendship>>> GetFriendships([FromRoute] int? userId)
        {
            try
            {
                if (userId != null)
                {
                    List<Friendship> friendships = _data.GetAllFriendsOfUser(userId.Value).Result;

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
        [HttpGet]
        [Route("{friendshipId}")]
        public async Task<ActionResult<Friendship>> GetFriendship([FromRoute] int? friendshipId)
        {
            try
            {
                if (friendshipId != null)
                {
                    Friendship friendship = _data.GetFriendship(friendshipId.Value).Result;

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