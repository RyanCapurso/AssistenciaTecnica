using AssistenciaTecnicaApi.Data.Dtos.Ordem;
using AssistenciaTecnicaApi.Data.Enums;
using AssistenciaTecnicaApi.Models;
using AutoMapper;

namespace AssistenciaTecnicaApi.Profiles;

public class OrdemProfile : Profile
{
    public OrdemProfile()
    {
        CreateMap<CreateOrdemDto, OrdemModel>();
        CreateMap<OrdemModel, ReadOrdemDto>().ForMember
        (
            responsavelDto => responsavelDto.Responsaveis,
            opts => opts.MapFrom
            (
                ordem => ordem.Responsavel
            )
        );
        CreateMap<OrdemModel, ReadOrdemClienteDto>();
        CreateMap<UpdateOrdemDto, OrdemModel>();
        CreateMap<OrdemModel, UpdateOrdemDto>();
    }
}