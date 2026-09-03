using ApiMasters.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMasters.Data.Repositories;

public class GeneroRepository : IGeneroRepository
{
    private readonly AppDbContext _context;

    public GeneroRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Criar(Genero genero)
    {
        _context.Generos.Add(genero);
    }

    public void Atualizar(Genero genero)
    {
        _context.Generos.Update(genero);
    }

    public void Deletar(Genero genero)
    {
        _context.Generos.Remove(genero);
    }

    public Task<Genero?> ObterPorIdAsync(int id)
    {
        return _context.Generos.FindAsync(id).AsTask();
    }

    public Task<Genero?> ObterPorNomeAsync(string nome)
    {
        return _context.Generos
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Nome == nome);
    }

    public Task<List<Genero>> ObterTodosAsync()
    {
        return _context.Generos
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<int> SalvarAlteracoesAsync()
    {
        return _context.SaveChangesAsync();
    }
}