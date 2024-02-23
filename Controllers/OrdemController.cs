using AssistenciaTecnicaApi.Data;
using AssistenciaTecnicaApi.Data.Dtos.Ordem;
using AssistenciaTecnicaApi.Data.Enums;
using AssistenciaTecnicaApi.Models;
using AssistenciaTecnicaApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaTecnicaApi.Controllers;
[ApiController]
[Route("[controller]")]
public class OrdemController : ControllerBase
{
     private IMapper _mapper;
    private AssistenciaContext _context;

    public OrdemController(IMapper mapper, AssistenciaContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaOrdem([FromBody] CreateOrdemDto OrdemDto)
    {
        var verificaConversao = CompararEnum.CompareStringComEnum(OrdemDto.Status);
        if(!verificaConversao)
        {
             throw new ArgumentException("A string não corresponde a nenhum valor do enum StatusEnum");
        }

        OrdemModel ordem = _mapper.Map<OrdemModel>(OrdemDto);
        
        _context.Ordens.Add(ordem);
        
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaOrdemPorId) , new {Id = ordem.IdOrdem}, OrdemDto);
    }

    [HttpGet]
    public IEnumerable<ReadOrdemDto> RecuperaOrdem
    (
        [FromQuery] int skip = 0,
        [FromQuery] int take = 100
    )
    {
        return _mapper.Map<List<ReadOrdemDto>>(_context.Ordens.Skip(skip).Take(take).ToList());
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaOrdemPorId(int id)
    {
        OrdemModel ordem = _context.Ordens.FirstOrDefault(ordem => ordem.IdOrdem == id);
        if (ordem != null)
        {
            ReadOrdemDto ordemDto = _mapper.Map<ReadOrdemDto>(ordem);
            return Ok(ordemDto);
        }
        return NotFound();
    }
    [HttpPut("{id}")]
    public IActionResult AtualizaOrdemPorId(int id, [FromBody] UpdateOrdemDto ordemDto)
    {
        var ordem = _context.Ordens
            .FirstOrDefault(ordem => ordem.IdOrdem == id);

        if (ordem == null) return NotFound();
        _mapper.Map(ordemDto,ordem);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizaDadosDoCliente(int id, JsonPatchDocument <UpdateOrdemDto> patch)
    {
        var ordem = _context.Ordens
            .FirstOrDefault(ordem => ordem.IdOrdem == id);

        if (ordem == null) return NotFound();
         
        var ordemParaAtualizar = _mapper.Map<UpdateOrdemDto>(ordem);

        patch.ApplyTo(ordemParaAtualizar, ModelState);

        if (!TryValidateModel(ordemParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(ordemParaAtualizar,ordem);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Deletaordem(int id)
    {
        OrdemModel ordem = _context.Ordens.FirstOrDefault(ordem => ordem.IdOrdem == id);
        if (ordem == null)
        {
            return NotFound();
        }
        _context.Remove(ordem);
        _context.SaveChanges();
        return NoContent();
    }
    
}

