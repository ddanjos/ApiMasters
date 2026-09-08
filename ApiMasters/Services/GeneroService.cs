using ApiMasters.Data.Repositories;
using ApiMasters.Models;

namespace ApiMasters.Services;

public class GeneroService : IGeneroService
{
    private readonly   IGeneroRepository _repository;
    public GeneroService(IGeneroRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<Genero>> ObterTodosAsync()
    {
        return await _repository.ObterTodosAsync();
    }

    public async Task<Genero?> ObterPorIdAsync(int id)
    {
        return await _repository.ObterPorIdAsync(id);
    }

    public Task<List<Genero>> ObterPorNomeAsync(string nome)
    {
        return _repository.ObterPorNomeAsync(nome);
    }

    public async Task<Genero> CriarAsync(Genero genero)
    {
        _repository.Criar(genero);
        await  _repository.SalvarAlteracoesAsync();
        return genero;
    }

    public async Task<bool> AtualizarAsync(int id, Genero generoAjustado)
    {
        var existente = await _repository.ObterPorIdAsync(id);
        if (existente is null) return false;

        existente.Nome =  generoAjustado.Nome;
                
        _repository.Atualizar(existente);
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
    
    public async Task<List<Genero>> ObterPorIdsAsync(List<int> ids)
    {
        if (ids == null || !ids.Any()) return new List<Genero>();
    
        return await _repository.ObterPorIdsAsync(ids);
    }
}