using ApiMasters.Models;

namespace ApiMasters.Services;

public interface IMusicaService
{
    Task<List<Musica>> ObterTodasAsync();
    Task<Musica?> ObterPorIdAsync(int id);
    Task<List<Musica>> ObterPorArtistaIdAsync(int artistaId);
    Task<List<Musica>> ObterPorGeneroIdAsync(int generoId);
    Task<Musica> CriarAsync(Musica musica);
    Task<bool> AtualizarAsync(int id, Musica musicaAjustada);
    Task<bool> DeletarAsync(int id);
}