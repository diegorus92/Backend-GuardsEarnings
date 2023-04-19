using GuardsEarnings_BL.Dtos;
using GuardsEarnings_BL.Services;
using GuardsEarnings_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuardsEarningsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneysController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneysController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }





        // GET: api/<JourneysController>
        [HttpGet]
        public IEnumerable<Journey> Get()
        {
            return _journeyService.GetJourneys();
        }

        // GET api/<JourneysController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journey>> Get(long id)
        {
            Journey? journey = _journeyService.GetJoureny(id);
            if(journey == null)
            {
                return NotFound("Journey not found");
            }
            return Ok(journey);
        }

        // POST api/<JourneysController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] JourneyDTO value)
        {
            _journeyService.CreateJourney(value);
            return Ok("Journey successfuly saved");
        }

        // PUT api/<JourneysController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(long id, [FromBody] JourneyDTO value)
        {
            var state = _journeyService.UpdateJourney(id, value);
            if (!state)
                return BadRequest("Journey not found to update");
            return Ok("Journey updated");
        }

        // DELETE api/<JourneysController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(long id)
        {
            var state = _journeyService.DeleteJourney(id);
            if (!state)
                return BadRequest("Journey not found to eliminate");
            return Ok("Journey removed");
        }
    }
}
