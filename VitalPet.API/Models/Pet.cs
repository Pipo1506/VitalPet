using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalPet.API.Models
{
    [Table("TB_PET")]
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do pet é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A espécie é obrigatória (ex: Cachorro, Gato).")]
        [StringLength(50)]
        public string Especie { get; set; }

        public string Raca { get; set; }

        public int Idade { get; set; }
        
        [Required]
        public int TutorId { get; set; } 

        [ForeignKey("TutorId")]
        public Tutor Tutor { get; set; } 
        
        public int? VeterinarioId { get; set; } // O ponto de interrogação "?" é porque é opcional, caso o pet ainda não tenha um veterinario
        

        [ForeignKey("VeterinarioId")]
        public Veterinario Veterinario { get; set; }
    }
}