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
    [Route("ChatServer")]
    public class ChatController : ControllerBase
    {
        private readonly IData _data;

        public ChatController([FromServices] IData data)
        {
            _data = data;
        }
       

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<List<Chat>>> GetAllChatsFromUser([FromRoute] int? userId)
        {
            try
            {
                if (userId != null)
                {
                    List<Chat> chats = _data.GetAllUserChats(userId.Value).Result;

                    return Ok(chats);
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