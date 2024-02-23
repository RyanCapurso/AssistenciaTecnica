
using AssistenciaTecnicaApi.Models;

namespace AssistenciaTecnicaApi.Data.Dtos;

public class ReadAparelhoDto
{
    public string Modelo { get; set; }
    public virtual ICollection<OrdemModel> Ordens { get; set; }
}