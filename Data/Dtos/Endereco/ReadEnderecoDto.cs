namespace AssistenciaTecnicaApi.Data.Dtos;

public class ReadEnderecoDto
{
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Municipio { get; set; }
    public int NumeroDaResidencia { get; set; }
    public string Cep { get; set; }

}