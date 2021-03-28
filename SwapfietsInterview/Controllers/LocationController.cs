using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwapfietsInterview.Libraries.BikeWiseApi;
using SwapfietsInterview.Libraries.BikeWiseApi.Request;
using SwapfietsInterview.Libraries.BikeWiseApi.Response;
using SwapfietsInterview.Models;

namespace SwapfietsInterview.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationContext _context;
        
        public LocationController(LocationContext context)
        {
            _context = context;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(long id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> ListAllLocation()
        {
            var locations = from l in _context.Locations select l;

            return await locations.ToListAsync();
        }

        [HttpGet("{id}/incident")]
        public async Task<ActionResult<string>> ListAllEventForLocation(long id)
        {
            var location = await GetLocation(id);
            var request = new BikeWiseApiRequestIncidents(location.Value);
            var response = BikeWiseApiLib.ExecuteRequest(request);

            if (response.GetType() == typeof(BikeWiseApiResponseIncidents))
            {
                return JsonSerializer.Serialize(
                    new {numberOfResult = ((BikeWiseApiResponseIncidents) response).NumberOfResults}
                );
            }

            return Problem("Could not reach BikeWise API.");
        }

        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocation), new {id = location.Id}, location);
        }
    }
}