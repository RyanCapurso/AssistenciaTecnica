using AssistenciaTecnicaApi.Data.Dtos;
using AssistenciaTecnicaApi.Models;
using AutoMapper;

namespace AssistenciaTecnicaApi.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {

        CreateMap<CreateClienteDto,ClienteModel>();

        CreateMap<ClienteModel, UpdateClienteDto>();
        CreateMap<UpdateClienteDto, ClienteModel>();
        
        CreateMap<ClienteModel, ReadClienteDto>();
        CreateMap<ClienteModel, ReadClienteOrdemDto>();

        CreateMap<ClienteEndereco, ReadClienteEnderecoDto>();
    }
}