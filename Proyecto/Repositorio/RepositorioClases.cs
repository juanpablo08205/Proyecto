using Proyecto.Data;
using Microsoft.EntityFrameworkCore;
namespace Proyecto.Repositorio

{
    public class RepositorioClases: IRepositorioClases
    {
        private readonly BDDirectorioDBContext _context;

        public RepositorioClases(BDDirectorioDBContext context)
        {
            _context = context;
        }

        public async Task Add(Clase clase)
        {
            await _context.Clases.AddAsync(clase);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var clase = await _context.Clases.FindAsync(id);

            if (clase == null)
            {
                throw new Exception("Clase no encontrada.");
            }

            var tieneUsuarios = await _context.Usuarios.AnyAsync(u => u.ClaseId == id);

            if (tieneUsuarios)
            {
                throw new Exception("Ya hay usuarios en esta clase.");
            }

            _context.Clases.Remove(clase);
            await _context.SaveChangesAsync();
        }


        public async Task<Clase> Get(int id)
        {
            return await _context.Clases.FindAsync(id);
        }

        public async Task<List<Clase>> GetAll()
        {
            return await _context.Clases.Include(_ => _.Usuarios).AsNoTracking().ToListAsync();
        }

        public async Task Update(Clase clase)
        {
            _context.Clases.Update(clase!);
            await _context.SaveChangesAsync();
        }
    }
}
