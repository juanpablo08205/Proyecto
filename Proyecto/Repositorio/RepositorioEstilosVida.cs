using Proyecto.Data;
using Microsoft.EntityFrameworkCore;

public class RepositorioEstilosVida : IRepositorioEstilosVida
{
    private readonly BDDirectorioDBContext _context;

    public RepositorioEstilosVida(BDDirectorioDBContext context)
    {
        _context = context;
    }

    public async Task<List<EstiloVida>> GetAll()
    {
        return await _context.EstilosVida.ToListAsync();
    }

    public async Task<EstiloVida> GetById(int id)
    {
        return await _context.EstilosVida.FindAsync(id);
    }

    public async Task Add(EstiloVida estilo)
    {
        _context.EstilosVida.Add(estilo);
        await _context.SaveChangesAsync();
    }

    public async Task Update(EstiloVida estilo)
    {
        _context.EstilosVida.Update(estilo);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var estilo = await GetById(id);
        if (estilo != null)
        {
            _context.EstilosVida.Remove(estilo);
            await _context.SaveChangesAsync();
        }
    }
}
