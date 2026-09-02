using ApiMasters.Models;

namespace ApiMasters.Data.Repositories
{
    public interface IArtistaRepository
    {
        Task<Artista?> CriarAsync(Artista artista);
        Task<Artista?> AtualizarAsync(Artista artista);
        Task DeletarAsync(int id);
        Task <Artista?> ObterPorIdAsync(int id)
        Task<IEnumerable<Artista>> BuscarPorNomeAsync(string termoBusca);
        Task<IEnumerable<Artista>> ObterTodosAsync();
    }
}
