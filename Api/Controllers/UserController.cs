using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.ICommands;
using Application.Queries;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _context;
        private IGetUsersCommand _getCommand;
        private IGetUserCommand _getOneCommand;

        public UserController(Context context, IGetUserCommand getUserCommand, IGetUsersCommand getUsersCommand)
        {
            _context = context;
            _getCommand = getUsersCommand;
            _getOneCommand = getUserCommand;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get([FromQuery] UserQuery query)
        {
            return Ok(_getCommand.Execute(query));
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var userDto = _getOneCommand.Execute(id);
                return Ok(userDto);
            }
            catch (EntityNotFoundException)
            {

                return NotFound();
            }
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
