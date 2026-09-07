using ApiMasters.DTOs;
using ApiMasters.Models;
using ApiMasters.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMasters.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ArtistaController : ControllerBase
{
    private readonly IArtistaService _service;

    public ArtistaController(IArtistaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ArtistaRespostaDto>>> ObterTodos()
    {
        var list = await _service.ObterTodosAsync();
        var listaResposta = list.Select(artista => new ArtistaRespostaDto
        {
            Id = artista.Id,
            Nome = artista.Nome,
            Nacionalidade = artista.Nacionalidade

        }).ToList();
        
        return Ok(listaResposta);
    }

    [HttpPost]
    public async Task<ActionResult<ArtistaRespostaDto>> Post([FromBody] ArtistaCriacaoDto dto)
    {
        var artista = new Artista
        {
            Nome = dto.Nome,
            Nacionalidade = dto.Nacionalidade
        };
        
        var novoArtista = await _service.CriarAsync(artista);

        var artistaResposta = new ArtistaRespostaDto
        {
            Id = artista.Id,
            Nome = artista.Nome,
            Nacionalidade = artista.Nacionalidade
        };
        
        return CreatedAtAction(nameof(ObterPorId), new { id = artistaResposta.Id }, artistaResposta);
    }
    
    [HttpGet("{id:int}")]
    
    public async Task<ActionResult<ArtistaRespostaDto>> ObterPorId(int id)    {
        var artista = await _service.ObterPorIdAsync(id);
        if (artista == null) return NotFound();

        var artistaResposta = new ArtistaRespostaDto
        {
            Id = artista.Id,
            Nome = artista.Nome,
            Nacionalidade = artista.Nacionalidade
        };
        
        return Ok(artistaResposta);
    }
    
    [HttpGet("buscar/{nome}")]
    public async Task<ActionResult<List<ArtistaRespostaDto>>> ObterPorNome(string nome)
    {
        var artistas = await _service.BuscarPorNomeAsync(nome);
        
        if (artistas == null || !artistas.Any()) 
            return NotFound($"Nenhum artista encontrado com o nome '{nome}'.");

        var artistaResposta = artistas.Select(a => new ArtistaRespostaDto
        {
            Id = a.Id,
            Nome = a.Nome,
            Nacionalidade = a.Nacionalidade
        }).ToList();

        return Ok(artistaResposta);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deletado  = await _service.DeletarAsync(id);
        if (!deletado) return NotFound();

        return NoContent();
    }
}   