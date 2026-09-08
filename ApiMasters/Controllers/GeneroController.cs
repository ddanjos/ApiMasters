using ApiMasters.DTOs;
using ApiMasters.Models;
using ApiMasters.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMasters.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeneroController : ControllerBase
{
    private readonly IGeneroService _service;

    public GeneroController(IGeneroService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<GeneroRespostaDto>>> ObterTodos()
    {
        var generos = await _service.ObterTodosAsync();

        var resposta = generos.Select(g => new GeneroRespostaDto
        {
            Id = g.Id,
            Nome = g.Nome
        }).ToList();

        return Ok(resposta);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GeneroRespostaDto>> ObterPorId(int id)
    {
        var encontrado = await _service.ObterPorIdAsync(id);
        if (encontrado is null) return NotFound();

        var resposta = new GeneroRespostaDto
        {
            Id = encontrado.Id,
            Nome = encontrado.Nome
        };
        
        return Ok(resposta);
    }

    [HttpGet("buscar")]
    public async Task<ActionResult<List<GeneroRespostaDto>>> ObterPorNome([FromQuery] string nome)
    {
        var buscaGenero = await _service.ObterPorNomeAsync(nome);

        var resposta = buscaGenero.Select(g => new GeneroRespostaDto
        {
            Id = g.Id,
            Nome = g.Nome
        }).ToList();

        return Ok(resposta); 
    }

    [HttpPost]
    public async Task<ActionResult<GeneroRespostaDto>> Criar([FromBody] GeneroCriacaoDto dto)
    {
        var genero = new Genero
        {
            Nome = dto.Nome
        };
        
        var criado = await _service.CriarAsync(genero);

        var resposta = new GeneroRespostaDto
        {
            Id = criado.Id,
            Nome = criado.Nome
        };

        return CreatedAtAction(nameof(ObterPorId), new { id = resposta.Id }, resposta);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<GeneroRespostaDto>> Atualizar(int id, [FromBody] GeneroAlteracaoDto dto)
    {
        var generoAtualizar = new Genero
        {
            Id = id,
            Nome = dto.Nome
        };
       
        var sucessoAtualizacao = await _service.AtualizarAsync(id, generoAtualizar);
        if (!sucessoAtualizacao) return NotFound();
        
        var resposta = new GeneroRespostaDto
        {
            Id = id,
            Nome = generoAtualizar.Nome
        };
        
        return Ok(resposta);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Deletar(int id)
    {
        var sucesso = await _service.DeletarAsync(id);
        if (!sucesso) return NotFound();
        
        return NoContent();
    }
}