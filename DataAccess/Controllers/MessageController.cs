using System;
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
        public async Task<ActionResult> UpdateMessageState([FromBody] Message message)
        {
            try
            {
                //_data.UpdateMessageState(message);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}