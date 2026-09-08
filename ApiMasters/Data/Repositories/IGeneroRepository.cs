using ApiMasters.Models;

namespace ApiMasters.Data.Repositories
{
    public interface IGeneroRepository
    {
        void Criar(Genero genero);
        void Atualizar(Genero genero);
        void Deletar(Genero genero);
        Task<Genero?> ObterPorIdAsync(int id);
        Task<List<Genero>> ObterPorNomeAsync(string nome);
        Task<List<Genero>> ObterTodosAsync();
        Task<List<Genero>> ObterPorIdsAsync(List<int> ids);
        Task<int> SalvarAlteracoesAsync();
    }
}