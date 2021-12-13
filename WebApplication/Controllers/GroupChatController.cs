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
    [Route("GroupChatServer")]
    public class GroupController : ControllerBase
    {
        private readonly IData _data;

        public GroupController([FromServices] IData data)
        {
            _data = data;
        }
        
        [HttpGet]
        [Route("OfUser/{userId}")]
        public async Task<ActionResult<List<GroupChat>>> GetUserGroupChats([FromRoute] int? userId)
        {
            try
            {
                if (userId != null)
                {
                    List<GroupChat> groupChats = _data.GetAllUserGroupChats(userId.Value).Result;

                    return Ok(groupChats);
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
        public async Task<ActionResult> CreateGroup([FromBody] GroupChat group)
        {
            try
            {
                await _data.CreateGroup(group);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> AddParticipantToGroup([FromQuery] int groupId, [FromQuery] string userToAdd)
        {
            try
            {
                
                await _data.AddParticipantToGroup(groupId,userToAdd);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteParticipantToGroup([FromQuery] int participantId)
        {
            try
            {
                await _data.RemoveParticipantFromGroup(participantId);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch]
        public async Task<ActionResult> PromoteParticipantToAdmin([FromQuery] int participantId)
        {
            try
            {
                await _data.PromoteParticipantToAdmin(participantId);
                
                return Ok();
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}