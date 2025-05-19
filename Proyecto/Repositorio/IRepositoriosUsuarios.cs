using Proyecto.Data;

namespace Proyecto.Repositorio;
    public interface IRepositorioUsuarios
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> Get(int id);
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(int id);
    }

