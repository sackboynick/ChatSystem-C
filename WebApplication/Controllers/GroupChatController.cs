using System;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]Server")]
    public class GroupController : ControllerBase
    {
        private readonly IData _data;

        public GroupController([FromServices] IData data)
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
                    GroupChat chat = _data.GetGroupChat(chatId.Value).Result;

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
        public async Task<ActionResult> CreateGroup([FromQuery] string groupCreator)
        {
            try
            {
                await _data.CreateGroup(groupCreator);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> AddParticipantToGroup([FromQuery] int groupId, [FromQuery] string userToAdd)
        {
            try
            {
                _data.AddParticipantToGroup(groupId,userToAdd);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteParticipantToGroup([FromQuery] int groupId, [FromQuery] string userToRemove)
        {
            try
            {
                _data.AddParticipantToGroup(groupId,userToRemove);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch]
        public async Task<ActionResult> PromoteParticipantToAdmin([FromQuery] int groupId, [FromQuery] string userToPromote)
        {
            try
            {
                _data.PromoteParticipantToAdmin(groupId,userToPromote);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}