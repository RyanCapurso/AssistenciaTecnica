using AssistenciaTecnicaApi.Data.Dtos;
using AssistenciaTecnicaApi.Models;
using AutoMapper;

namespace AssistenciaTecnicaApi.Profiles;

public class AparelhoProfile : Profile
{
    public AparelhoProfile()
    {
        CreateMap<CreateAparelhoDto, AparelhoModel>();
        CreateMap<AparelhoModel, ReadAparelhoDto>();
        CreateMap<UpdateAparelhoDto, AparelhoModel>();
        CreateMap<AparelhoModel, UpdateAparelhoDto>();
        CreateMap<AparelhoModel, ReadAparelhoOrdemDto>();
    }
}