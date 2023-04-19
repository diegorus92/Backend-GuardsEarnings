using GuardsEarnings_BL.Dtos;
using GuardsEarnings_BL.Services;
using GuardsEarnings_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuardsEarningsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly IWorkService _workService;

        public WorksController(IWorkService workService)
        {
            _workService = workService;
        }





        // GET: api/<WorksController>
        [HttpGet]
        public IEnumerable<Work> Get()
        {
            return _workService.GetWorks();
        }

        // GET api/<WorksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> Get(long id)
        {
            Work? work = _workService.GetWork(id);
            if(work == null)
                return NotFound("Work not found");
            return Ok(work);
        }

        // POST api/<WorksController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] WorkDTO value)
        {
            var state = _workService.CreateWork(value);
            if (!state) return BadRequest("Not found: Guard, Target or Journey");
            return Ok("Work successfuly saved");
        }

        // PUT api/<WorksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(long id, [FromBody] WorkDTO value)
        {
            var state = _workService.UpdateWork(id, value);
            if (!state) return BadRequest("Work not found to update");
            return Ok("Work updates");
        }

        // DELETE api/<WorksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(long id)
        {
            var state = _workService.DeleteWork(id);
            if (!state) return BadRequest("Work not found to eliminate");
            return Ok("Work removed");
        }
    }
}
