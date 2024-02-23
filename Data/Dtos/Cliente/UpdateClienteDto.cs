namespace AssistenciaTecnicaApi.Data.Dtos;

public class UpdateClienteDto
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}