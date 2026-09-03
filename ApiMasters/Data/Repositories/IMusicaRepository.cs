using ApiMasters.Models;

namespace ApiMasters.Data.Repositories
{
    public interface IMusicaRepository
    {
        void Criar(Musica musica);
        void Atualizar(Musica musica);
        void Deletar(Musica musica);
        Task<int> SalvarAlteracoesAsync();
        Task<Musica?> ObterPorIdAsync(int id);
        Task<List<Musica>> ObterTodasAsync();
        Task<List<Musica>> ObterPorArtistaIdAsync(int id);
        Task<List<Musica>> ObterPorGeneroIdAsync(int generoId);
     

    }
}