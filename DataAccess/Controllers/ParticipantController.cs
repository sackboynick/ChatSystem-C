using System;
using System.Threading.Tasks;
using Domain.Data;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : Controller
    {
        private readonly IDataRepo _data;

        public ParticipantController([FromServices] IDataRepo data)
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
                    Participant participant = _data.GetParticipant(participantId.Value);

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
        public async Task<ActionResult> AddParticipant([FromBody] Participant participant)
        {
            try
            {
                _data.AddParticipant(participant);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateParticipant([FromBody] Participant participant)
        {
            try
            {
                _data.UpdateParticipant(participant);
                
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
                    _data.RemoveParticipant(participantId.Value);
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