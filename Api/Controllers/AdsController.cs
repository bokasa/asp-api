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

        [HttpPost]
        public IActionResult Post([FromQuery] AdDTO ad)
        {
            var ads = new Ad
            {
                Title = ad.Title,
                Body = ad.Body,
                Price = ad.Price,
                IsShipping = ad.IsShipping
            };

            _context.Ads.Add(ads);

            try
            {
                _context.SaveChanges();

                return Created("/api/ads/" + ads.Id, new AdDTO
                {
                    Id = ads.Id,
                    Title = ad.Title,
                    Body = ad.Body,
                    Price = ad.Price,
                    IsShipping = ad.IsShipping
                });
            }
            catch
            {
                return StatusCode(500, "An error has occured.");
            }
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromQuery] AdDTO ad)
        {
            var ads = _context.Ads.Find(id);

            if (ads == null)
            {
                return NotFound();
            }

            if (ads.IsDeleted)
            {
                return NotFound();
            }

            ads.Title = ad.Title;
            ads.Body = ad.Body;
            ads.Price = ad.Price;
            ads.IsShipping = ad.IsShipping;

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
            var ad = _context.Ads.Find(id);

            if (ad == null)
            {
                return NotFound();
            }

            if (ad.IsDeleted)
                return Conflict("This ad is already deleted.");

            ad.IsDeleted = true;

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
