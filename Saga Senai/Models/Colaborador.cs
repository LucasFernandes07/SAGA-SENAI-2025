using System.ComponentModel.DataAnnotations;

namespace TarefasApp.Models
{
    public class Colaborador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Setor { get; set; }

        public int Pontos { get; set; } = 0;
    }
}
