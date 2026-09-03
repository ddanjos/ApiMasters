using ApiMasters.Models;

namespace ApiMasters.Data.Repositories
{
    public interface IArtistaRepository
    {
        Task<List<Artista>> ObterTodosAsync();
        Task<Artista?> ObterPorIdAsync(int id);
        Task<List<Artista>> BuscarPorNomeAsync(string termoBusca);
    
        void Criar(Artista artista);
        void Atualizar(Artista artista);
        void Deletar(Artista artista);
    
        Task<int> SalvarAlteracoesAsync();
    }
}
