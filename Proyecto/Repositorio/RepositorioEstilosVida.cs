using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        var estiloVida = await _context.EstilosVida
            .Include(e => e.Usuarios)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (estiloVida == null)
        {
            throw new Exception("Estilo de vida no encontrado.");
        }

        if (estiloVida.Usuarios != null && estiloVida.Usuarios.Any())
        {
            throw new Exception("Hay usuarios que cuentan con este estilo de vida.");
        }

        _context.EstilosVida.Remove(estiloVida);
        await _context.SaveChangesAsync();
    }

}
