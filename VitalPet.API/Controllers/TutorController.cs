using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitalPet.API.Data;
using VitalPet.API.Models;

namespace VitalPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly AppDbContext _context;

      
        public TutorController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutores()
        {
      
            return Ok(await _context.Tutores.ToListAsync()); 
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
            {
                return NotFound(); 
            }
            return Ok(tutor); 
        }
        
        [HttpGet("buscar-por-nome")]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutorPorNome([FromQuery] string nome)
        {
            var tutores = await _context.Tutores
                .Where(t => t.Nome.Contains(nome))
                .ToListAsync();

            if (!tutores.Any())
            {
                return NotFound("Nenhum tutor encontrado com esse nome."); 
            }

            return Ok(tutores); 
        }
        
        [HttpPost]
        public async Task<ActionResult<Tutor>> PostTutor(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetTutor), new { id = tutor.Id }, tutor); 
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor(int id, Tutor tutor)
        {
            if (id != tutor.Id)
            {
                return BadRequest("O ID da URL não coincide com o ID do corpo da requisição."); 
            }

            _context.Entry(tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
                {
                    return NotFound(); 
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool TutorExists(int id)
        {
            return _context.Tutores.Any(e => e.Id == id);
        }
    }
}