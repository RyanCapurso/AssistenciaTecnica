
using AssistenciaTecnicaApi.Data.Enums;
using AssistenciaTecnicaApi.Models;

namespace AssistenciaTecnicaApi.Data.Dtos.Ordem;

public class UpdateOrdemDto
{
    public string Descricao { get; set; }
    public string Status { get; set; }
    public int IdResponsavel { get; set; }
    public int IdCliente { get; set; }
    public virtual UpdateAparelhoDto Aparelho { get; set; }
}