using Microsoft.EntityFrameworkCore;
using VitalPet.API.Models;

namespace VitalPet.API.Data
{ public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
    }
}