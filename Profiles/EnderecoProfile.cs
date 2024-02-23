using AssistenciaTecnicaApi.Data.Dtos;
using AssistenciaTecnicaApi.Models;
using AutoMapper;

namespace AssistenciaTecnicaApi.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, EnderecoModel>();

        CreateMap<EnderecoModel, ReadEnderecoDto>();
        
        CreateMap<EnderecoModel, UpdateEnderecoDto>();
        CreateMap<UpdateEnderecoDto, EnderecoModel>();
        
    }
}