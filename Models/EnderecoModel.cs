using System.ComponentModel.DataAnnotations;

namespace AssistenciaTecnicaApi.Models;

public class EnderecoModel
{
    [Key]
    [Required]
    public int IdEndereco { get; set; }
    [Required(ErrorMessage = "O logradouro é obrigatorio")]
    [MaxLength(50)]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O Bairro é obrigatorio")]
    [MaxLength(15)]
    public string Bairro { get; set; }
    [Required(ErrorMessage = "O Municipio é obrigatorio")]
    [MaxLength(20)]
    public string Municipio { get; set; }
    [Required(ErrorMessage = "O Numero da Residencia é obrigatorio")]
    public int NumeroDaResidencia { get; set; }
    [Required(ErrorMessage = "O logradouro é obrigatorio")]
    [MaxLength(8)]
    public string Cep { get; set; }
    public virtual ICollection<ClienteEndereco> ClienteEndereco { get; set; }

    
}