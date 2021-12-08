using System;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IDataRepo _data;

        public GroupController([FromServices] IDataRepo data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{chatId}")]
        public async Task<ActionResult<GroupChat>> GetChat([FromRoute] int? chatId)
        {
            try
            {
                if (chatId != null)
                {
                    GroupChat chat = _data.GetGroupChat(chatId.Value);

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
        public async Task<ActionResult> CreateGroup([FromBody] GroupChat groupChat)
        {
            try
            {
                _data.CreateGroup(groupChat);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateGroup([FromBody] GroupChat groupChat)
        {
            try
            {
                _data.UpdateGroup(groupChat);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}