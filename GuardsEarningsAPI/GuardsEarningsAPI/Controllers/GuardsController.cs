using GuardsEarnings_BL.Dtos;
using GuardsEarnings_BL.Services;
using GuardsEarnings_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuardsEarningsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardsController : ControllerBase
    {
        private readonly IGuardService _guardService;

        public GuardsController(IGuardService guardService)
        {
            _guardService = guardService;
        }




        // GET: api/<GuardsController>
        [HttpGet]
        public IEnumerable<Guard> Get()
        {
            return _guardService.GetGuards() ;
        }

        // GET api/<GuardsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guard>> Get(long id)
        {
            Guard? guard = _guardService.GetGuard(id);

            if(guard == null)
            {
                return NotFound("Guard not found. ID non-existent") ;
            }
            return guard;
        }

        // POST api/<GuardsController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] GuardDTO value)
        {
            _guardService.CreateGuard(value);
            return Ok("Guard saved succesfully");
        }

        // PUT api/<GuardsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(long id, [FromBody] GuardDTO value)
        {
            var state =  _guardService.UpdateGuard(id, value);
            if (!state)
            {
                return NotFound("Guard not found to update");
            }
            return Ok("Successful Update");
        }

        // DELETE api/<GuardsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(long id)
        {
            var state = _guardService.DeleteGuard(id);
            if (!state)
                return BadRequest("Guard not found to eliminate");
            return Ok("Guard removed successfuly");
        }
    }
}
