using System;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("ParticipantServer")]
    public class ParticipantController : Controller
    {
        private readonly IData _data;

        public ParticipantController([FromServices] IData data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{participantId}")]
        public async Task<ActionResult<Participant>> GetParticipant([FromRoute] int? participantId)
        {
            try
            {
                if (participantId != null)
                {
                    Participant participant = _data.GetParticipant(participantId.Value).Result;

                    return Ok(participant);
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
        public async Task<ActionResult> AddParticipant([FromQuery] int groupId,[FromQuery] string userToAdd)
        {
            try
            {
                await _data.AddParticipantToGroup(groupId,userToAdd);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> PromoteParticipantToAdmin(int participantId)
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
        [HttpDelete]
        [Route("{participantId}")]
        public async Task<ActionResult> RemoveParticipant([FromRoute] int? participantId)
        {
            try
            {
                if (participantId != null)
                {
                    await _data.RemoveParticipantFromGroup(participantId.Value);
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