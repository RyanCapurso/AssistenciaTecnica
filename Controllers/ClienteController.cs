using AssistenciaTecnicaApi.Data;
using AssistenciaTecnicaApi.Data.Dtos;
using AssistenciaTecnicaApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssistenciaTecnicaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private IMapper _mapper;
    private AssistenciaContext _context;

    public ClienteController(IMapper mapper, AssistenciaContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaCliente([FromBody] CreateUsuarioDto usuarioDto)
    {
        ClienteModel cliente = _mapper.Map<ClienteModel>(usuarioDto.createClienteDto);
        EnderecoModel endereco = _mapper.Map<EnderecoModel>(usuarioDto.createEnderecoDto);

        _context.Enderecos.Add(endereco);
        _context.Clientes.Add(cliente);
    
        _context.SaveChanges();

        
        var clienteEndereco = new ClienteEndereco
        {
            IdCliente= cliente.IdCliente,
            IdEndereco = endereco.IdEndereco
        };

        _context.ClientesEnderecos.Add(clienteEndereco);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaClientePorId) , new {Id = cliente.IdCliente}, usuarioDto);
    }
    [HttpGet]
    public IEnumerable<ReadClienteEnderecoDto> RecuperaCliente
    (
        [FromQuery] int skip = 0,
        [FromQuery] int take = 100,
        [FromQuery] string? nomeCliente = null
    )
    {
        if(nomeCliente == null) 
        {
            return _mapper.Map<List<ReadClienteEnderecoDto>>(_context.ClientesEnderecos.Skip(skip).Take(take).ToList());
        }
        return _mapper.Map<List<ReadClienteEnderecoDto>>(_context.ClientesEnderecos.Skip(skip).Take(take)
        .Where(cliente => cliente.Cliente.Nome == nomeCliente).ToList());

    }
    [HttpGet("{id}")]
    public IActionResult RecuperaClientePorId(int id)
    {
        ClienteEndereco cliente = _context.ClientesEnderecos.FirstOrDefault(cliente => cliente.IdCliente == id);
        
        if (cliente != null)
        {
            ReadClienteEnderecoDto clienteDto = _mapper.Map<ReadClienteEnderecoDto>(cliente);
            return Ok(clienteDto);
        }
        return NotFound();
    }
    [HttpPut("{id}")]
    public IActionResult AtualizaClientePorId(int id, [FromBody] UpdateClienteDto clienteDto)
    {
        var cliente = _context.Clientes
            .FirstOrDefault(cliente => cliente.IdCliente == id);

        if (cliente == null) return NotFound();
        _mapper.Map(clienteDto,cliente);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizaDadosDoCliente(int id, JsonPatchDocument <UpdateClienteDto> patch)
    {
        var cliente = _context.Clientes
            .FirstOrDefault(cliente => cliente.IdCliente == id);

        if (cliente == null) return NotFound();
         
        var clienteParaAtualizar = _mapper.Map<UpdateClienteDto>(cliente);

        patch.ApplyTo(clienteParaAtualizar, ModelState);

        if (!TryValidateModel(clienteParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(clienteParaAtualizar,cliente);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeletaCliente(int id)
    {
        ClienteModel cliente = _context.Clientes.FirstOrDefault(cliente => cliente.IdCliente == id);
        EnderecoModel endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.IdEndereco == id);
        if (cliente == null)
        {
            return NotFound();
        }
        if (endereco != null)
        {
            _context.Remove(endereco);
        }
        _context.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
    
}
