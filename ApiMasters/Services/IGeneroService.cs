using ApiMasters.Models;

namespace ApiMasters.Services;

public interface IGeneroService
{
    Task<List<Genero>> ObterTodosAsync();
    Task<Genero?> ObterPorIdAsync(int id);
    Task<Genero?> ObterPorNomeAsync(string nome);
    Task<Genero> CriarAsync(Genero genero);
    Task<bool> AtualizarAsync(int id, Genero generoAjustado);

    Task<List<Genero>> ObterPorIdsAsync(List<int> ids);
    Task<bool> DeletarAsync(int id);
}