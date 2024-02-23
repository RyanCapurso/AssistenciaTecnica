using System.ComponentModel.DataAnnotations;

namespace AssistenciaTecnicaApi.Models;

public class ResponsavelModel
{   
    [Key]
    [Required]
    public int IdResponsavel { get; set; }
    [Required(ErrorMessage = "O nome do Responsável é Obrigatorio")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O Cargo do Responsável é Obrigatorio")]
    public string Cargo { get; set; }
    public virtual ICollection<OrdemModel> Ordens { get; set; }

}