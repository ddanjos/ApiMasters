using ApiMasters.Data.Repositories;
using ApiMasters.DTOs;
using ApiMasters.Models;

namespace ApiMasters.Services;

public class MusicaService :IMusicaService
{
    private readonly IMusicaRepository _repository;
    
    public  MusicaService(IMusicaRepository repository)
    {
        this._repository = repository;
    }

    public async Task<PagedResult<MusicaRespostaDto>> ObterTodasAsync(MusicaFiltroDTO filtro)
    {
        var resultadoPaginado = await _repository.ObterTodasAsync(filtro);

        var musicasDto = resultadoPaginado.Items.Select(m => new MusicaRespostaDto
        {
            Id = m.Id,
            Nome = m.Nome,
            Duracao = m.Duracao,
            ArtistaId = m.ArtistaId,
            Generos = m.Generos.Select(g => new GeneroRespostaDto
            {
                Id = g.Id,
                Nome = g.Nome
            }).ToList()
        }).ToList();

        return new PagedResult<MusicaRespostaDto>(
            musicasDto,
            resultadoPaginado.Page,
            resultadoPaginado.PageSize,
            resultadoPaginado.TotalItems
        );
    }

    public Task<Musica?> ObterPorIdAsync(int id)
    {
        return  _repository.ObterPorIdAsync(id);
    }

    public Task<List<Musica>> ObterPorArtistaIdAsync(int artistaId)
    {
        return _repository.ObterPorArtistaIdAsync(artistaId);
    }

    public Task<List<Musica>> ObterPorGeneroIdAsync(int generoId)
    {
       return _repository.ObterPorGeneroIdAsync(generoId);
    }

    public async Task<Musica> CriarAsync(Musica musica)
    {
        _repository.Criar(musica);
        await _repository.SalvarAlteracoesAsync();
        return musica;
    }

    public async Task<bool> AtualizarAsync(int id, Musica musicaAjustada)
    {
       var existente = await _repository.ObterPorIdAsync(id);
       if (existente is null) return false;
       _repository.Atualizar(musicaAjustada);
       await _repository.SalvarAlteracoesAsync();
       return true;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var existente = await _repository.ObterPorIdAsync(id);
        if (existente is null) return false;
        _repository.Deletar(existente);
        await _repository.SalvarAlteracoesAsync();
        return true;
    }
}