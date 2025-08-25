using System.ComponentModel.DataAnnotations;

namespace ald_controls.Models;

public class Colaborador
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    public string Setor { get; set; } = string.Empty;

    public int Pontos { get; set; }

    public Colaborador()
    {
        Pontos = 0;
    }

}