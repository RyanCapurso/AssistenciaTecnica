
namespace AssistenciaTecnicaApi.Models;

public class ClienteEndereco
{
    public int IdCliente { get; set; }
    public virtual ClienteModel Cliente { get; set; }

    public int IdEndereco { get; set; }
    public virtual EnderecoModel Endereco { get; set; }
}