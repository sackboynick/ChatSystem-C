using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrivateChatController : ControllerBase
    {
        private readonly IDataRepo _data;

        public PrivateChatController([FromServices] IDataRepo data)
        {
            _data = data;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<PrivateChat>>> GetPrivateChats()
        {
            try
            {
                List<PrivateChat> privateChats = _data.GetPrivateChats();

                return Ok(privateChats);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{privateChatId}")]
        public async Task<ActionResult<PrivateChat>> GetPrivateChat([FromRoute] int? privateChatId)
        {
            try
            {
                if (privateChatId != null)
                {
                    PrivateChat chat = _data.GetPrivateChat(privateChatId.Value);

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
        public async Task<ActionResult> SendPrivateMessage([FromBody] Message message)
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