using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalPet.API.Models
{
    [Table("TB_VETERINARIO")]
    public class Veterinario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do veterinário é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CRMV é obrigatório.")]
        [StringLength(20)]
        public string Crmv { get; set; }
        
        public int? ClinicaId { get; set; } // "?" porque o veterinario pode ser autonomo

        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }

       
        public ICollection<Pet> Pets { get; set; }
    }
}