public interface IRepositorioEstilosVida
{
    Task<List<EstiloVida>> GetAll();
    Task<EstiloVida> GetById(int id);       // <-- Agregar este método
    Task Add(EstiloVida estilo);
    Task Update(EstiloVida estilo);         // <-- Agregar este método
    Task Delete(int id);
}
