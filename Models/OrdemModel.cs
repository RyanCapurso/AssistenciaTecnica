using System.ComponentModel.DataAnnotations;
using AssistenciaTecnicaApi.Data.Enums;

namespace AssistenciaTecnicaApi.Models;

public class OrdemModel
{
    [Key]
    [Required]
    public int IdOrdem { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public string Status { get; set; }
    public string Descricao { get; set; }
    public int IdResponsavel { get; set; }
    public virtual ResponsavelModel Responsavel { get; set; }
    public int IdCliente { get; set; }
    public virtual ClienteModel Cliente { get; set; }
    public int IdAparelho { get; set; }
    public virtual AparelhoModel Aparelho { get; set; }
}