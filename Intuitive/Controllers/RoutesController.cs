using System;
using Intuitive.Context;
using Intuitive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intuitive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController: ControllerBase
	{
        private readonly ApplicationDbContext _context;

        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RouteAirports>> Get()
        {
            return _context.Route.ToList();
        }
        [HttpPost]
        public ActionResult<RouteAirports> Post([FromBody] RouteAirports newRoute)
        {
            if (newRoute == null)
            {
                return BadRequest("newRoute data is null.");
            }
            if (_context.Route.Any(r=>r.RouteId == newRoute.RouteId))
            {
                return BadRequest("Route already exists.");
            }
            //refactor
            if (_context.Airports.Any(r => r.AirportId != newRoute.ArrivalAirportId))
            {
                return BadRequest("The ArrivalAirportId doesn't exist in the aiports table.");
            }
            if (_context.Airports.Any(r => r.AirportId != newRoute.DepartureAirportId))
            {
                return BadRequest("The DepartureAirportId doesn't exist in the aiports table.");
            }
            var itExist = _context.Route.Where(c => c.ArrivalAirportId == newRoute.ArrivalAirportId &&
            c.DepartureAirportId == newRoute.DepartureAirportId).ToList();

            if (itExist.Any())
            {
                return BadRequest($"A Route with the same airports already exists in the table.");
            }
            _context.Route.Add(newRoute);
            _context.SaveChanges();

            return Ok();
        }
    }
}

