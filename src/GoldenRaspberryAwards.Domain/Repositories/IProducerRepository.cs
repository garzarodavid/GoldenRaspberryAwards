using GoldenRaspberryAwards.Domain.Entities;

namespace GoldenRaspberryAwards.Domain.Repositories;

public interface IProducerRepository
{
    Task<Producer> GetByNameAsync(string name);
    Task AddAsync(Producer producer);
}