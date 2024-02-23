namespace AssistenciaTecnicaApi.Data.Dtos;

public class CreateClienteDto
{
    public string Nome { get; set; } 
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}