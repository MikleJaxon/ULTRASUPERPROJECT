using DISCREESTR.DOMAIN;
using DISCREESTR.Infrastructure.Data;
using DISCREESTR.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DISCREESTR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrepController : ControllerBase
    {
        private readonly Context _context;
        private readonly PrepRepository _prepRepository;

        public PrepController(Context context)
        {
            _context = context;
            _prepRepository = new PrepRepository(_context);
        }

        // GET: api/<PrepCOntroller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prep>>> GetPreps()
        {
            return await _prepRepository.GetAllPrepsAsync();
        }

        // GET api/<PrepCOntroller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prep>> GetPrep(int Id)
        {
            var prep = await _prepRepository.GetByIdAsync(Id);
            if (prep == null)
            {
                return NotFound();
            }
            return prep;
        }

        // POST api/<PrepCOntroller>
        [HttpPost]
        public async Task<ActionResult<Prep>> PostPrep(Prep prep)
        {
            await _prepRepository.AddPrepAsync(prep);
            return CreatedAtAction("GetPrep", new { id = prep.Id }, prep);
        }

        // PUT api/<PrepCOntroller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrep(int Id, Prep prep)
        {
            if (Id != prep.Id)
            {
                return BadRequest();
            }
            await _prepRepository.UpdatePrepAsync(prep);
            return NoContent();
        }

        // DELETE api/<PrepCOntroller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrep(int Id)
        {
            var prep = await _prepRepository.GetByIdAsync(Id);
            if (prep == null)
            {
                return NotFound();
            }
            await _prepRepository.DeletePrepAsync(Id);
            return NoContent();
        }
        private bool PredmExist(int Id)
        {
            return _context.Preps.Any(e => e.Id == Id);
        }
    }
}
