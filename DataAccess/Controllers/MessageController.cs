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
    public class MessageController : Controller
    {
        private readonly IDataRepo _data;
        
        public MessageController([FromServices] IDataRepo data)
        {
            _data = data;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Message>>> GetMessages()
        {
            try
            {
                List<Message> messages = _data.GetMessages();

                return Ok(messages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{messageId}")]
        public async Task<ActionResult<Message>> GetMessage([FromRoute] int? messageId)
        {
            try
            {
                if (messageId != null)
                {
                    Message message = _data.GetMessage(messageId.Value);

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
                _data.SendMessage(message);

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
                _data.UpdateMessage(message);
                
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
                    _data.RemoveMessage(messageId.Value);

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