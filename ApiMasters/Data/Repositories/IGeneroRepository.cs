using ApiMasters.Models;

namespace ApiMasters.Data.Repositories
{
    public interface IGeneroRepository
    {
        void Criar(Genero genero);
        void Atualizar(Genero genero);
        void Deletar(Genero genero);
        Task<Genero?> ObterPorIdAsync(int id);
        Task<Genero?> ObterPorNomeAsync(string nome);
        Task<List<Genero>> ObterTodosAsync();
        
    }
}