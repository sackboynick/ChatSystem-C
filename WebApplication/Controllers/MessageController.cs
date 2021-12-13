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
    [Route("MessageServer")]
    public class MessageController : Controller
    {
        private readonly IData _data;
        
        public MessageController([FromServices] IData data)
        {
            _data = data;
        }
        [HttpGet]
        [Route("Group/{groupId}")]
        public async Task<ActionResult<List<Message>>> GetAllGroupMessages([FromRoute] int? groupId)
        {
            try
            {
                if (groupId != null)
                {
                    List<Message> messages = _data.GetAllGroupMessages(groupId.Value).Result;

                    return Ok(messages);
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
        [Route("PrivateChat/{chatId}")]
        public async Task<ActionResult<List<Message>>> GetAllPrivateChatMessages([FromRoute] int? chatId)
        {
            try
            {
                if (chatId != null)
                {
                    List<Message> messages = _data.GetAllChatMessages(chatId.Value).Result;

                    return Ok(messages);
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
        [Route("{messageId}")]
        public async Task<ActionResult<Message>> GetMessage([FromRoute] int? messageId)
        {
            try
            {
                if (messageId != null)
                {
                    Message message = _data.GetMessage(messageId.Value).Result;

                    return Ok(message);
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
                await _data.SendMessage(message);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateMessage([FromBody] Message message)
        {
            try
            {
                if (message.PinnedMessage != null && message.PinnedMessage.Value)
                {
                    await _data.UpdateMessage(message);
                }
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete]
        [Route("{messageId}")]
        public async Task<ActionResult> RemoveMessage([FromRoute] int? messageId)
        {
            try
            {
                if (messageId != null)
                {
                    await _data.RemoveMessage(messageId.Value);

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