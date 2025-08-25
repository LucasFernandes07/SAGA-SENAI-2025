using System.ComponentModel.DataAnnotations;

namespace ald_controls.Models
{
    public class Epi
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;
    }
}