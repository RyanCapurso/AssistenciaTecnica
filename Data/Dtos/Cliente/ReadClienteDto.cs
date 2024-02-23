using AssistenciaTecnicaApi.Data.Dtos.Ordem;
using AssistenciaTecnicaApi.Models;

namespace AssistenciaTecnicaApi.Data.Dtos;

public class ReadClienteDto
{
    public string Nome { get; set; } 
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public virtual ICollection<ReadOrdemClienteDto> Ordens { get; set; }
    
}