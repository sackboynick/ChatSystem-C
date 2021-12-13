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
    [Route("PrivateChatServer")]
    public class PrivateChatController : ControllerBase
    {
        private readonly IData _data;

        public PrivateChatController([FromServices] IData data)
        {
            _data = data;
        }
        
        [HttpGet]
        [Route("OfUser/{userId}")]
        public async Task<ActionResult<List<PrivateChat>>> GetUserPrivateChats([FromRoute] int? userId)
        {
            try
            {
                if (userId != null)
                {
                    List<PrivateChat> privateChats = _data.GetAllUserPrivateChats(userId.Value).Result;

                    return Ok(privateChats);
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
        [Route("{chatId}")]
        public async Task<ActionResult<PrivateChat>> GetPrivateChat([FromRoute] int? chatId)
        {
            try
            {
                if (chatId != null)
                {
                    PrivateChat chat = _data.GetPrivateChat(chatId.Value).Result;

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
        

        
    }
}