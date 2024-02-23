using AssistenciaTecnicaApi.Data;
using AssistenciaTecnicaApi.Data.Dtos;
using AssistenciaTecnicaApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaTecnicaApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AparelhoController : ControllerBase
{
      private IMapper _mapper;
    private AssistenciaContext _context;

    public AparelhoController(IMapper mapper, AssistenciaContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaAparelho([FromBody] CreateAparelhoDto aparelhoDto)
    {
        AparelhoModel aparelho = _mapper.Map<AparelhoModel>(aparelhoDto);
        _context.Aparelhos.Add(aparelho);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaAparelhoPorId) , new {Id = aparelho.IdAparelho}, aparelhoDto);
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaAparelhoPorId(int id)
    {
        AparelhoModel aparelho = _context.Aparelhos.FirstOrDefault(aparelho => aparelho.IdAparelho == id);
        if (aparelho != null)
        {
            ReadAparelhoDto aparelhoDto = _mapper.Map<ReadAparelhoDto>(aparelho);
            return Ok(aparelhoDto);
        }
        return NotFound();
    }
    [HttpPut("{id}")]
    public IActionResult AtualizaAparelhoPorId(int id, [FromBody] UpdateAparelhoDto aparelhoDto)
    {
        var aparelho = _context.Aparelhos
            .FirstOrDefault(aparelho => aparelho.IdAparelho == id);

        if (aparelho == null) return NotFound();
        _mapper.Map(aparelhoDto,aparelho);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizaDadosDoAparelho(int id, JsonPatchDocument <UpdateAparelhoDto> patch)
    {
        var aparelho = _context.Aparelhos
            .FirstOrDefault(aparelho => aparelho.IdAparelho == id);

        if (aparelho == null) return NotFound();
         
        var aparelhoParaAtualizar = _mapper.Map<UpdateAparelhoDto>(aparelho);

        patch.ApplyTo(aparelhoParaAtualizar, ModelState);

        if (!TryValidateModel(aparelhoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(aparelhoParaAtualizar,aparelho);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeletaAparelho(int id)
    {
        AparelhoModel aparelho = _context.Aparelhos.FirstOrDefault(aparelho => aparelho.IdAparelho == id);
        if (aparelho == null)
        {
            return NotFound();
        }
        _context.Remove(aparelho);
        _context.SaveChanges();
        return NoContent();
    }
}