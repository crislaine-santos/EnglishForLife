using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnglishForLife.Models
{
    public class Turma
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required string NomeTurma { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required string Nivel { get; set; }

        [JsonIgnore]
        public ICollection<Aluno>? Alunos { get; set; }

    }
}
