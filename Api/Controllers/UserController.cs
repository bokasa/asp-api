using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Exceptions;
using Application.ICommands;
using Application.Queries;
using Domain;
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
        [HttpPost]
        public IActionResult Post([FromQuery] UserDTO user)
        {
            var users = new User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email
            };

            _context.Users.Add(users);

            try
            {
                _context.SaveChanges();

                return Created("/api/users/" + users.Id, new UserDTO
                {
                    Id = users.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email
                });
            }
            catch
            {
                return StatusCode(500, "An error has occured.");
            }
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromQuery] UserDTO user)
        {
            var users = _context.Users.Find(id);

            if (users == null)
            {
                return NotFound();
            }

            if (users.IsDeleted)
            {
                return NotFound();
            }

            users.Username = user.Username;
            users.Password = user.Password;
            users.Email = user.Email;

            try
            {
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured.");
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            if (user.IsDeleted)
                return Conflict("This user is already deleted.");

            user.IsDeleted = true;

            try
            {
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
