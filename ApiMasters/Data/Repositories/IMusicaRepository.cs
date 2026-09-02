using ApiMasters.Models;

namespace ApiMasters.Data.Repositories
{
    public interface IMusicaRepository
    {
        Task<Musica> CriarAsync(Musica musica);
        Task<Musica?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Musica>> ObterTodasAsync();
        Task<IEnumerable<Musica>> ObterPorArtistaIdAsync(Guid artistaId);
        Task<IEnumerable<Musica>> ObterPorGeneroIdAsync(int generoId);
        Task AtualizarAsync(Musica musica);
        Task DeletarAsync(Guid id);
    }
}