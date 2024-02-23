
namespace AssistenciaTecnicaApi.Data.Dtos;

public class ReadClienteOrdemDto
{
    public string Nome { get; set; } 
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}