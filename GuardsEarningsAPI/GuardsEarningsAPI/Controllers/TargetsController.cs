using GuardsEarnings_BL.Dtos;
using GuardsEarnings_BL.Services;
using GuardsEarnings_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuardsEarningsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetsController : ControllerBase
    {
        private readonly ITargetService _targetService;

        public TargetsController(ITargetService targetService)
        {
            _targetService = targetService;
        }





        // GET: api/<TargetsController>
        [HttpGet]
        public IEnumerable<Target> Get()
        {
            return _targetService.GetTargets();
        }

        // GET api/<TargetsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Target>> Get(long id)
        {
            Target? target = _targetService.GetTarget(id);
            if (target == null)
                return NotFound("Target not found. ID non-existent");
            return target;
        }

        // POST api/<TargetsController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] TargetDTO value)
        {
            _targetService.CreateTarget(value);
            return Ok("Target saved successfuly");
        }

        // PUT api/<TargetsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(long id, [FromBody] TargetDTO value)
        {
            var state = _targetService.UpdateTarget(id, value);
            if (!state)
                return BadRequest("Target not found to update");
            return Ok("Successful update");
        }

        // DELETE api/<TargetsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var state = _targetService.DeleteTarget(id);
            if (!state)
                return NotFound("Target not found to eliminate");
            return Ok("Target successfuly removed");
        }
    }
}
