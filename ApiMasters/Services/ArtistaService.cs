using ApiMasters.Data.Repositories;
using ApiMasters.Models;

namespace ApiMasters.Services;

public class ArtistaService : IArtistaService
{
    private readonly IArtistaRepository  _repository;

    public ArtistaService(IArtistaRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Artista>> ObterTodosAsync()
    {
        return _repository.ObterTodosAsync();
    }

    public Task<Artista?> ObterPorIdAsync(int id)
    {
        return _repository.ObterPorIdAsync(id); }

    public Task<List<Artista>> BuscarPorNomeAsync(string termoBusca)
    {
       return _repository.BuscarPorNomeAsync(termoBusca);
    }

    public async Task<Artista> CriarAsync(Artista artista)
    {
        _repository.Criar(artista);
        await _repository.SalvarAlteracoesAsync();
        return artista;
    }

    public async Task<bool> AtualizarAsync(int id, Artista artistaAjustado)
    {
        var existente = await _repository.ObterPorIdAsync(id);
        if (existente == null) return false;
        
        existente.Nome =  artistaAjustado.Nome;
        existente.Nacionalidade = artistaAjustado.Nacionalidade;
        _repository.Atualizar(artistaAjustado);
        
        await _repository.SalvarAlteracoesAsync();
        return true;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var existente = await _repository.ObterPorIdAsync(id);
        if (existente == null) return false;
        
        _repository.Deletar(existente);
        await _repository.SalvarAlteracoesAsync();
        return true;
    }
}