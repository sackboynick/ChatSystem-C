using System;
using System.Threading.Tasks;
using DataAccess.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IUserService _data;

        public ChatController([FromServices] IUserService data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{chatId}")]
        public async Task<ActionResult<Chat>> GetAdult([FromRoute] int? chatId)
        {
            try
            {
                if (chatId != null)
                {
                    //Chat chat = _data.GetChat(chatId.Value);

                    //return Ok(chat);
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