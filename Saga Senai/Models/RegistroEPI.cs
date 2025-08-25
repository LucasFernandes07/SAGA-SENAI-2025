using System;
using System.ComponentModel.DataAnnotations;

namespace TarefasApp.Models
{
    public class RegistroEPI
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ColaboradorId { get; set; }
    public Colaborador? Colaborador { get; set; }

        [Required]
        public string EPI { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now;
        public int Pontos { get; set; } = 10;
    }
}
