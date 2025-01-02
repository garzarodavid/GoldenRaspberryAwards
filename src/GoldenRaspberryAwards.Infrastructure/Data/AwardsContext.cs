using GoldenRaspberryAwards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAwards.Infrastructure.Data;

public class AwardsContext : DbContext
{
    public AwardsContext(DbContextOptions<AwardsContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Producer> Producers { get; set; }
}