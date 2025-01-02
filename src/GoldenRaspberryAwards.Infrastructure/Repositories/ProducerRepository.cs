using GoldenRaspberryAwards.Domain.Entities;
using GoldenRaspberryAwards.Domain.Repositories;
using GoldenRaspberryAwards.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAwards.Infrastructure.Repositories;

public class ProducerRepository : IProducerRepository
{
    private readonly AwardsContext _context;

    public ProducerRepository(AwardsContext context)
    {
        _context = context;
    }

    public async Task<Producer> GetByNameAsync(string name)
    {
        return await _context.Producers.FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task AddAsync(Producer producer)
    {
        await _context.Producers.AddAsync(producer);
        await _context.SaveChangesAsync();
    }
}