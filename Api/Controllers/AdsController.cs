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
        public IActionResult Post([FromBody]AdDTO dto)
        {
            var ad = new Ad
            {
                Title = dto.Title,
                Body = dto.Body,
                Price = dto.Price,
                IsShipping = dto.IsShipping
            };

            _context.Ads.Add(ad);

            try
            {
                _context.SaveChanges();

                return Created("/api/ads/" + ad.Id, new AdDTO
                {
                    Id = ad.Id,
                    Title = ad.Title,
                    Body = ad.Body,
                    Price = ad.Price,
                    IsShipping = ad.IsShipping
                });
            }
            catch
            {
                return StatusCode(500, "An error has occured !!");
            }
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
