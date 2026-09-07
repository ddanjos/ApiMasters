using ApiMasters.DTOs;
using ApiMasters.Models;
using ApiMasters.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiMasters.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MusicaController : ControllerBase
{
    private readonly IMusicaService _service;
    
    public MusicaController(IMusicaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<MusicaRespostaDto>>> ObterTodos()
    {
        var musicas = await _service.ObterTodasAsync();
    
        var resposta = musicas.Select(m => new MusicaRespostaDto
        {
            Id = m.Id,
            Nome = m.Nome,
            Duracao = m.Duracao,
            ArtistaId = m.ArtistaId,
            Generos = m.Generos.Select(g => new GeneroRespostaDto
            {
                Nome = g.Nome
            }).ToList()
            
        }).ToList();

        return resposta;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MusicaRespostaDto>> ObterPorId(int id)
    {
        var musica = await _service.ObterPorIdAsync(id);
        if (musica is null) return NotFound();

        var resposta = new MusicaRespostaDto
        {
            Id = musica.Id,
            Nome = musica.Nome,
            ArtistaId = musica.ArtistaId,

            Generos = musica.Generos.Select(m => new GeneroRespostaDto
            {
                Nome = m.Nome

            }).ToList(),
            Duracao = musica.Duracao
        };
        return resposta;
    }

    [HttpPost]
    public async Task<ActionResult<MusicaRespostaDto>> Adicionar([FromBody] MusicaCriacaoDto dto, [FromServices] IGeneroService  serviceGenero)
    {
        var generosDoBanco = await serviceGenero.ObterPorIdsAsync(dto.GenerosIds);
        
        var novaMusica = new Musica
        {
            Nome = dto.Nome,
            Duracao = dto.Duracao,
            ArtistaId = dto.ArtistaId,
            Generos = generosDoBanco // Atribui a List<Genero> retornada
        };
        
        var musicaCriada = await _service.CriarAsync(novaMusica);
        
        var resposta = new MusicaRespostaDto
        {
            Id = musicaCriada.Id,
            Nome = musicaCriada.Nome,
            Duracao = musicaCriada.Duracao,
            ArtistaId = musicaCriada.ArtistaId,
            Generos = musicaCriada.Generos.Select(g => new GeneroRespostaDto
            {
                Id = g.Id,
                Nome = g.Nome
            }).ToList()
        };

        return CreatedAtAction(nameof(ObterPorId), new { id = resposta.Id }, resposta);
    }
}