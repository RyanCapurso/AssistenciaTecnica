
using AssistenciaTecnicaApi.Data.Dtos;
using AssistenciaTecnicaApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;

namespace AssistenciaTecnicaApi.Profiles;

public class ClienteEnderecoProfile : Profile
{
    public ClienteEnderecoProfile()
        {
        

            CreateMap<CreateUsuarioDto, ClienteEndereco>()
            .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.createClienteDto))
            .ForMember(dest => dest.IdEndereco, opt => opt.MapFrom(src => src.createEnderecoDto));

            CreateMap<ClienteEndereco, ReadClienteEnderecoDto>();

            CreateMap<ReadClienteEnderecoDto, ClienteEndereco>();
            
        }
}