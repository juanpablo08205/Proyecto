using Proyecto.Data;

namespace Proyecto.Repositorio

{
    public interface IRepositorioClases 
    {
        Task<List<Clase>> GetAll();
        Task<Clase> Get(int id);
        Task Add(Clase clase);
        Task Update(Clase clase);
        Task Delete(int id);
    }
}
