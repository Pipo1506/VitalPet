using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitalPet.API.Data;
using VitalPet.API.Models;

namespace VitalPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            var pets = await _context.Pets.Include(p => p.Tutor).ToListAsync();
            return Ok(pets);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Tutor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }
        
        [HttpGet("buscar-por-especie")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetPorEspecie([FromQuery] string especie)
        {
            var pets = await _context.Pets
                .Include(p => p.Tutor)
                .Where(p => p.Especie.ToLower().Contains(especie.ToLower()))
                .ToListAsync();

            if (!pets.Any())
            {
                return NotFound("Nenhum pet encontrado para esta espécie.");
            }

            return Ok(pets);
        }
        
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            var tutorExiste = await _context.Tutores.AnyAsync(t => t.Id == pet.TutorId);
            if (!tutorExiste)
            {
                return BadRequest("O Tutor informado não existe. Por favor, cadastre o tutor primeiro.");
            }

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest("O ID da URL não coincide com o ID do corpo da requisição.");
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}