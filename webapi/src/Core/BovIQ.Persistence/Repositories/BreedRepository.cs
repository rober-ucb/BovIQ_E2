using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BovIQ.Persistence.Repositories;

public class BreedRepository(ApplicationDbContext context) : BaseRepository<Breed, int>(context), IBreedRepository
{
    public Task<bool> BredNameExistsAsync(string name, int id) 
        => Context.Breeds.Where(x => x.Id != id).AnyAsync(x => x.Name == name);

    public Task<bool> BredNameExistsAsync(string name) 
        => Context.Breeds.AnyAsync(x => x.Name == name);
}
