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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ArtistaRespostaDto>> ObterPorId(int id)
    {
        var artista = await _service.ObterPorIdAsync(id);
        if (artista is null) return NotFound();

        var artistaResposta = new ArtistaRespostaDto
        {
            Id = artista.Id,
            Nome = artista.Nome,
            Nacionalidade = artista.Nacionalidade
        };
        
        return Ok(artistaResposta);
    }

    [HttpGet("buscar")]
    public async Task<ActionResult<List<ArtistaRespostaDto>>> ObterPorNome([FromQuery] string nome)
    {
        var artistas = await _service.BuscarPorNomeAsync(nome);
        
        var artistaResposta = artistas.Select(a => new ArtistaRespostaDto
        {
            Id = a.Id,
            Nome = a.Nome,
            Nacionalidade = a.Nacionalidade
        }).ToList();

        return Ok(artistaResposta);
    }

    [HttpPost]
    public async Task<ActionResult<ArtistaRespostaDto>> Criar([FromBody] ArtistaCriacaoDto dto)
    {
        var artista = new Artista
        {
            Nome = dto.Nome,
            Nacionalidade = dto.Nacionalidade
        };
        
        var novoArtista = await _service.CriarAsync(artista);

        var artistaResposta = new ArtistaRespostaDto
        {
            Id = novoArtista.Id,
            Nome = novoArtista.Nome,
            Nacionalidade = novoArtista.Nacionalidade
        };
        
        return CreatedAtAction(nameof(ObterPorId), new { id = artistaResposta.Id }, artistaResposta);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ArtistaRespostaDto>> Atualizar(int id, [FromBody] ArtistaAlteracaoDto dto)
    {
        var artistaAtualizar = new Artista
        {
            Id = id,
            Nome = dto.Nome,
            Nacionalidade = dto.Nacionalidade
        };

        var sucesso = await _service.AtualizarAsync(id, artistaAtualizar);
        if (!sucesso) return NotFound();

        var resposta = new ArtistaRespostaDto
        {
            Id = id,
            Nome = artistaAtualizar.Nome,
            Nacionalidade = artistaAtualizar.Nacionalidade
        };

        return Ok(resposta);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deletado = await _service.DeletarAsync(id);
        if (!deletado) return NotFound();

        return NoContent();
    }
}