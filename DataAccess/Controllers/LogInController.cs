using System;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Persistence;
using Domain.User;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogInController : ControllerBase
    {
        private readonly IUserValidation _data;

        public LogInController([FromServices] IUserValidation data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("{username}/{password}")]
        public async Task<ActionResult<User>> ValidateUser([FromRoute] string username,[FromRoute] string password )
        {
            try
            {
                User user = _data.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            try
            {
                _data.RegisterUser(user);
                
                return Ok(user);
            }catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}