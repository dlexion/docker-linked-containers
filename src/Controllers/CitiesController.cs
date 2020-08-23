using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cities.Models;

namespace Cities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesContext _context;

        public CitiesController(CitiesContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var cities = _context.Cities.ToList();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var citiy = _context.Cities.FirstOrDefault(x => id == x.Id);
            return Ok(citiy);
        }

        [HttpPost]
        public IActionResult Post([FromBody] City value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Cities.Add(value);
            _context.SaveChanges();

            return Ok(value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] City value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var city = _context.Cities.Find(id);

            if (city == null)
            {
                return NotFound();
            }

            city.Name = value.Name;
            city.Contry = value.Contry;
            city.Population = value.Population;

            _context.SaveChanges();

            return Ok(city);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var city = _context.Cities.Find(id);

            if (city == null)
            {
                return NotFound();
            }

            _context.Remove(city);
            _context.SaveChanges();

            return Ok(city);
        }
    }
}
