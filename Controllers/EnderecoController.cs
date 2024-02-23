using AssistenciaTecnicaApi.Data;
using AssistenciaTecnicaApi.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaTecnicaApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    
    private AssistenciaContext _context;
    private IMapper _mapper;

    public EnderecoController(AssistenciaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<ReadEnderecoClienteDto> RecuperaEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoClienteDto>>(_context.Enderecos);

    }

}