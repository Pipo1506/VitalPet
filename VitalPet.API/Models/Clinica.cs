using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalPet.API.Models
{
    [Table("TB_CLINICA")]
    public class Clinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da clínica é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(18)] 
        public string Cnpj { get; set; }

        [StringLength(200)]
        public string Endereco { get; set; }
        
        public ICollection<Veterinario> Veterinarios { get; set; }
    }
}