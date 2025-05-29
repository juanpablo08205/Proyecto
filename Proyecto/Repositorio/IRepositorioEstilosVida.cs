using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepositorioEstilosVida
{
    Task<List<EstiloVida>> GetAll();
    Task<EstiloVida> GetById(int id);
    Task Add(EstiloVida estilo);
    Task Update(EstiloVida estilo);
    Task Delete(int id);
}
