using ApiMasters.Models;

namespace ApiMasters.Data.Repositories
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly AppDbContext _context;

        public ArtistaRepository(AppDbContext context)
        {
            _context = context;
        }   

        public Task<Artista?> AtualizarAsync(Artista artista)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artista>> BuscarPorNomeAsync(string termoBusca)
        {
            throw new NotImplementedException();
        }

        public Task<Artista?> CriarAsync(Artista artista)
        {
            throw new NotImplementedException();
        }

        public Task DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Artista?> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artista>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
