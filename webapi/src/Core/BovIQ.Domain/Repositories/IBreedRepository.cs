using BovIQ.Domain.Entities;

namespace BovIQ.Domain.Repositories;

public interface IBreedRepository : IBaseRepository<Breed, int>  
{
    Task<bool> BredNameExistsAsync(string name, int id);
    Task<bool> BredNameExistsAsync(string name);
}
