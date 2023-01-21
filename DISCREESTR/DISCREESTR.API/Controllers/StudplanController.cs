using DISCREESTR.DOMAIN;
using DISCREESTR.Infrastructure.Data;
using DISCREESTR.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DISCREESTR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudplanController : ControllerBase
    {
        private readonly Context _context;
        private readonly StudplanRepository _StudplanRepository;

        public StudplanController(Context context)
        {
            _context = context;
            _StudplanRepository = new StudplanRepository(_context);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studplan>>> GetStudplans()
        {
            return await _StudplanRepository.GetAllAsync();
        }




        // GET api/<ValuesController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Studplan>>> GetStudplan(int Id)
        {
            var studplan = await _StudplanRepository.GetStudplanAsync(Id);
            if (studplan == null)
            {
                return NotFound();
            }
            return Ok(studplan);
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Studplan>> PostStudplan(Studplan studplan)
        {
            await _StudplanRepository.AddStudplanAsync(studplan);
            return CreatedAtAction("GetStudplan", new { id = studplan.Id }, studplan);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscipline(int Id, Studplan studplan)
        {
            if (Id != studplan.Id)
            {
                return BadRequest();
            }
            await _StudplanRepository.UpdateStudplanAsync(studplan);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudplan(int Id)
        {
            var studplan = await _StudplanRepository.GetStudplanAsync(Id);
            if (studplan == null)
            {
                return NotFound();
            }
            await _StudplanRepository.DeleteAsync(Id);
            return NoContent();
        }
        private bool StudplanExist(int Id)
        {
            return _context.Studplans.Any(p => p.Id == Id);
        }
    }
}
