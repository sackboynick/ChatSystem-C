using System;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("PrivateChatServer")]
    public class PrivateChatController : ControllerBase
    {
        private readonly IDataRepo _data;

        public PrivateChatController([FromServices] IDataRepo data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{chatId}")]
        public async Task<ActionResult<PrivateChat>> GetPrivateChat([FromRoute] int? chatId)
        {
            try
            {
                if (chatId != null)
                {
                    PrivateChat chat = _data.GetPrivateChat(chatId.Value);

                    return Ok(chat);
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
        public async Task<ActionResult> SendMessage([FromBody] Message message)
        {
            try
            {
                _data.SendMessage(message);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        
    }
}