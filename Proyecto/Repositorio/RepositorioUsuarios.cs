using Proyecto.Data;
using Proyecto.Repositorio;
using Microsoft.EntityFrameworkCore;
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly BDDirectorioDBContext _context;

        public RepositorioUsuarios(BDDirectorioDBContext context)
        {
            _context = context;
        }

    public async Task<List<Usuario>> GetAll()
    {
        return await _context.Usuarios
            .Include(u => u.Clase) // si también necesitas mostrar la clase
            .Include(u => u.EstilosVida)
            .ToListAsync();
    }



    public async Task<Usuario> Get(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var usuario = await Get(id);
            if (usuario is not null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }

