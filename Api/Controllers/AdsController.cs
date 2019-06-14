using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.ICommands;
using Application.Queries;
using EfDataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : Controller
    {

        private readonly Context _context;
        private IGetAdsCommand _getCommand;
        private IGetAdCommand _getOneCommand;

        public AdsController(Context context, IGetAdsCommand getCommand, IGetAdCommand getOneCommand)
        {
            _context = context;
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get([FromQuery] AdQuery query)
        {
            return Ok(_getCommand.Execute(query));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var adDto = _getOneCommand.Execute(id);
                return Ok(adDto);
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
