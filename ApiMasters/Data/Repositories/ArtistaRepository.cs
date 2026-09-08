using ApiMasters.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMasters.Data.Repositories
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly AppDbContext _context;

        public ArtistaRepository(AppDbContext context)
        {
            _context = context;
        }   

        public void Atualizar(Artista artista)
        {
             _context.Artistas.Update(artista);
        }


        public void Criar(Artista artista)
        {
             _context.Artistas.Add(artista);
        }
        
        public void Deletar(Artista artista)
        {
             _context.Artistas.Remove(artista);
        }

        public Task<List<Artista>> BuscarPorNomeAsync(string termoBusca)
        {
            return _context.Artistas
                .AsNoTracking()
                .Where(a => EF.Functions.Like(a.Nome, $"%{termoBusca}%"))
                .ToListAsync();
        }
        
        public Task<Artista?> ObterPorIdAsync(int id)
        {
            return _context.Artistas
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        
        public Task<List<Artista>> ObterTodosAsync()
        {
            return _context.Artistas
                .AsNoTracking()
                .ToListAsync();
        }
        
        public Task<int> SalvarAlteracoesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}