using System.ComponentModel.DataAnnotations;

namespace AssistenciaTecnicaApi.Models;

public class AparelhoModel
{
    [Key]
    [Required]
    public int IdAparelho { get; set; }
    public string? Modelo { get; set; }
    public virtual ICollection<OrdemModel> Ordens { get; set; }
}