using ApiMasters.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

    public async Task<List<Genero>> ObterPorNomeAsync(string nome)
    {
        return await _context.Generos
            .AsNoTracking()
            .Where(g => g.Nome.Contains(nome))
            .ToListAsync();
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
    
    public async Task<List<Genero>> ObterPorIdsAsync(List<int> ids)
    {
        return await _context.Generos
            .Where(g => ids.Contains(g.Id))
            .ToListAsync();
    }
}