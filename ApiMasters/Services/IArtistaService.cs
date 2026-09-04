using ApiMasters.Models;

namespace ApiMasters.Services;

public interface IArtistaService
{
    Task<List<Artista>> ObterTodosAsync();
    Task<Artista?> ObterPorIdAsync(int id);
    Task<List<Artista>> BuscarPorNomeAsync(string termoBusca);
    Task<Artista> CriarAsync(Artista artista);
    Task<bool> AtualizarAsync(int id, Artista artistaAjustado);
    Task<bool> DeletarAsync(int id);
}