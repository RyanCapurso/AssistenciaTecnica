using AssistenciaTecnicaApi.Data;
using AssistenciaTecnicaApi.Data.Dtos.Responsavel;
using AssistenciaTecnicaApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaTecnicaApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ResponsavelController : ControllerBase
{
    private IMapper _mapper;
    private AssistenciaContext _context;

    public ResponsavelController(IMapper mapper, AssistenciaContext context)
    {
        _mapper = mapper;
        _context = context;
    }

     [HttpPost]
    public IActionResult AdicionaResponsavel([FromBody] CreateResponsavelDto responsavelDto)
    {
        ResponsavelModel responsavel = _mapper.Map<ResponsavelModel>(responsavelDto);
        _context.Responsaveis.Add(responsavel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaResponsavelPorId) , new {Id = responsavel.IdResponsavel}, responsavelDto);
    }
    [HttpGet]
    public IEnumerable<ReadResponsavelDto> RecuperaResponsavel
    (
        [FromQuery] int skip = 0,
        [FromQuery] int take = 100,
        [FromQuery] string? nomeResponsavel = null
    )
    {
        if(nomeResponsavel == null) 
        {
            return _mapper.Map<List<ReadResponsavelDto>>(_context.Responsaveis.Skip(skip).Take(take).ToList());
        }
        return _mapper.Map<List<ReadResponsavelDto>>(_context.Responsaveis.Skip(skip).Take(take)
        .Where(responsavel => responsavel.Nome == nomeResponsavel). ToList());

    }
    [HttpGet("{id}")]
    public IActionResult RecuperaResponsavelPorId(int id)
    {
        ResponsavelModel responsavel = _context.Responsaveis.FirstOrDefault(responsavel => responsavel.IdResponsavel == id);
        if (responsavel != null)
        {
            ReadResponsavelDto responsavelDto = _mapper.Map<ReadResponsavelDto>(responsavel);
            return Ok(responsavelDto);
        }
        return NotFound();
    }
    [HttpPut("{id}")]
    public IActionResult AtualizaResponsavelPorId(int id, [FromBody] UpdateResponsavelDto ResponsavelDto)
    {
        var responsavel = _context.Responsaveis
            .FirstOrDefault(responsavel => responsavel.IdResponsavel == id);

        if (responsavel == null) return NotFound();
        _mapper.Map(ResponsavelDto,responsavel);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizaDadosDoResponsavel(int id, JsonPatchDocument <UpdateResponsavelDto> patch)
    {
        var responsavel = _context.Responsaveis
            .FirstOrDefault(responsavel => responsavel.IdResponsavel == id);

        if (responsavel == null) return NotFound();
         
        var responsavelParaAtualizar = _mapper.Map<UpdateResponsavelDto>(responsavel);

        patch.ApplyTo(responsavelParaAtualizar, ModelState);

        if (!TryValidateModel(responsavelParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(responsavelParaAtualizar,responsavel);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeletaResponsavel(int id)
    {
        ResponsavelModel responsavel = _context.Responsaveis.FirstOrDefault(responsavel => responsavel.IdResponsavel == id);
        if (responsavel == null)
        {
            return NotFound();
        }
        _context.Remove(responsavel);
        _context.SaveChanges();
        return NoContent();
    }
}