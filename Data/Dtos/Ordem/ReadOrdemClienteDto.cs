
using AssistenciaTecnicaApi.Data.Dtos.Responsavel;
using AssistenciaTecnicaApi.Data.Enums;
using AssistenciaTecnicaApi.Models;

namespace AssistenciaTecnicaApi.Data.Dtos.Ordem;

public class ReadOrdemClienteDto
{
    public int IdOrdem { get; set; }
    public string Status { get; set; }
}
    