using AssistenciaTecnicaApi.Data.Dtos.Responsavel;
using AssistenciaTecnicaApi.Models;
using AutoMapper;

namespace AssistenciaTecnicaApi.Profiles;

public class ResponsavelProfile : Profile
{
    public ResponsavelProfile()
    {
        CreateMap<CreateResponsavelDto, ResponsavelModel>();
        CreateMap<ResponsavelModel, ReadResponsavelDto>();
        CreateMap<UpdateResponsavelDto, ResponsavelModel>();
        CreateMap<ResponsavelModel, UpdateResponsavelDto>();
    }
}