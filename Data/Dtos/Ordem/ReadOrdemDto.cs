
using AssistenciaTecnicaApi.Data.Dtos.Responsavel;
using AssistenciaTecnicaApi.Data.Enums;
using AssistenciaTecnicaApi.Models;

namespace AssistenciaTecnicaApi.Data.Dtos.Ordem;

public class ReadOrdemDto
{
    public int IdOrdem { get; set; }
    public virtual ReadClienteOrdemDto Cliente { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }
    public DateTime Data { get; set; }
    public virtual ReadResponsavelDto Responsaveis { get; set; }
    public virtual ReadAparelhoOrdemDto Aparelho { get; set; }
}
    