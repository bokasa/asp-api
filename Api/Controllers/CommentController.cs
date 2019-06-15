using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.ICommands.Comment;
using Application.Queries;
using EfDataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly Context _context;
        private IGetCommentsCommand _getCommand;
        private IGetCommentCommand _getOneCommand;

        public CommentController(Context context, IGetCommentsCommand getCommentsCommand, IGetCommentCommand getCommentCommand)
        {
            _context = context;
            _getCommand = getCommentsCommand;
            _getOneCommand = getCommentCommand;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get([FromQuery] CommentQuery query)
        {
            return Ok(_getCommand.Execute(query));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var commentDto = _getOneCommand.Execute(id);
                return Ok(commentDto);
            }
            catch (EntityNotFoundException)
            {

                return NotFound();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
