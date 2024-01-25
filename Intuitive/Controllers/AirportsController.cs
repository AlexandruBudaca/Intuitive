using System;
using System.Net;
using Intuitive.Context;
using Intuitive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intuitive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController: ControllerBase
	{
        private readonly ApplicationDbContext _context;

        public AirportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Airport>> Get()
        {
            return _context.Airports.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Airport> Get(int id)
        {
            var item = _context.Airports.Find(id);
            if (item == null)
                return new StatusCodeResult(404);

            return item;
        }
    }
}

