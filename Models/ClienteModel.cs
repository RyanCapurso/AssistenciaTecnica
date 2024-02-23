using System.ComponentModel.DataAnnotations;

namespace AssistenciaTecnicaApi.Models;

public class ClienteModel
{

    [Key]
    [Required]
    public int IdCliente { get; set; }
    public virtual int IdOrdem { get; set; }
    public string Nome { get; set; } 
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public virtual ICollection<ClienteEndereco> ClienteEndereco { get; set; }
    public virtual ICollection<OrdemModel> Ordens { get; set; }

    
}