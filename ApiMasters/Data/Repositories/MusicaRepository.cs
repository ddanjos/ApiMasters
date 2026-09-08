using ApiMasters.DTOs;
using ApiMasters.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMasters.Data.Repositories;

public class MusicaRepository : IMusicaRepository
{
    private readonly AppDbContext _context;

    public MusicaRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Criar(Musica musica)
    {
        _context.Add(musica);
    }

    public Task<Musica?> ObterPorIdAsync(int id)
    {
        return _context.Musicas.
            Include(musica => musica.Generos )
            .Include(m => m.Artista)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<PagedResult<Musica>> ObterTodasAsync(MusicaFiltroDTO filtro)
    {
      IQueryable<Musica> query = _context.Musicas
            .Include(m => m.Generos)
            .Include(m => m.Artista)
            .AsNoTracking();

        var totalCount = query.Count();
        var itens = await query.Skip(filtro.Skip)
            .Take(filtro.PageSize)
            .ToListAsync();

        return new PagedResult<Musica>
        {
            Items = itens,
            Page = filtro.Page,
            PageSize = filtro.PageSize,
            TotalItems = totalCount
        };

    }

    public Task<List<Musica>> ObterPorArtistaIdAsync(int id)
    {
        return _context.Musicas.
            AsNoTracking()
            .Where(a => a.ArtistaId ==  id).ToListAsync();  
    }

    public Task<List<Musica>> ObterPorGeneroIdAsync(int generoId)
    {
        return _context.Musicas.AsNoTracking()
            .Where(m => m.Generos.Any(g => g.Id == generoId))
            .ToListAsync();
    }

    public void Atualizar(Musica musica)
    {
        _context.Musicas.Update(musica);
    }

    public void Deletar(Musica musica)
    {
        _context.Musicas.Remove(musica);
    }

    public Task<int> SalvarAlteracoesAsync()
    {
       return _context.SaveChangesAsync();
    }
}