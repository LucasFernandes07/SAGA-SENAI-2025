using System.ComponentModel.DataAnnotations;

namespace ald_controls.Models;

public class RegistroEpi
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ColaboradorId { get; set; }
    public Colaborador? Colaborador { get; set; }

    [Required]
    public int EpiId { get; set; }
    public Epi? Epi { get; set; }

    public DateTime DataRegistro { get; set; }
    public int Pontos { get; set; }

    public RegistroEpi()
    {
        Colaborador = new Colaborador();
        Pontos = 10;
        DataRegistro = DateTime.Now;
    }
}