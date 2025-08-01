using System.ComponentModel.DataAnnotations;

namespace EnglishForLife.Models
{
    public class AlunoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50)]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
        public required string Email { get; set; }
    }
}
