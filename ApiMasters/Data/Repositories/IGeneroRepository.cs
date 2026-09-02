using ApiMasters.Models;

namespace ApiMasters.Data.Repositories
{
    public interface IGeneroRepository
    {
        Task<Genero> CriarAsync(Genero genero);
        Task<Genero?> ObterPorIdAsync(int id);
        Task<Genero?> ObterPorNomeAsync(string nome);
        Task<IEnumerable<Genero>> ObterTodosAsync();
        Task DeletarAsync(int id);
    }
}