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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GuardsController>
        [HttpPost]
        public void Post([FromBody] Guard value)
        {
            _guardService.CreateGuard(value);
        }

        // PUT api/<GuardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GuardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
