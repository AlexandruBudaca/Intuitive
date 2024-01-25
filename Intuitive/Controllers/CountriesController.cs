using System;
using Intuitive.Context;
using Intuitive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intuitive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController:ControllerBase
	{
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GeographyLevel1>> Get()
        {
            return _context.GeographyLevel1.Include(a => a.Airports).Select(
                g=> new GeographyLevel1
                {
                    GeographyLevel1Id = g.GeographyLevel1Id,
                    Name = g.Name,
                    Airports = g.Airports.ToList()
                }).ToList();
        }

        [HttpPost]
        public ActionResult<GeographyLevel1> Post([FromBody] GeographyLevel1 newGeography)
        {
            if (newGeography == null)
            {
                return BadRequest("GeographyLevels data is null.");
            }
            _context.GeographyLevel1.Add(newGeography);
            _context.SaveChanges();

            return Ok(newGeography);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.GeographyLevel1.Find(id);

            if (item == null)
            {
                return NotFound($"Item with ID {id} not found.");
            }
            var isInAirports = _context.Airports.Any(c => c.GeographyLevel1Id == id);

            if (isInAirports)
            {
                return BadRequest($"Cannot delete GeographyLevel with ID: {id} because it exists in the Airports table.");
            }


            _context.GeographyLevel1.Remove(item);
            _context.SaveChanges();

            return Ok();
        }

    }
}

