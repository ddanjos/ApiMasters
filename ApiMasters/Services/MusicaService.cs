using ApiMasters.Data.Repositories;
using ApiMasters.Models;

namespace ApiMasters.Services;

public class MusicaService :IMusicaService
{
    private readonly IMusicaRepository _repository;
    
    public  MusicaService(IMusicaRepository repository)
    {
        this._repository = repository;
    }
    
    public Task<List<Musica>> ObterTodasAsync()
    {
        return _repository.ObterTodasAsync();
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