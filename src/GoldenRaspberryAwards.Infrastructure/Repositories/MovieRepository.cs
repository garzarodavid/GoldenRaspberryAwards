using GoldenRaspberryAwards.Domain.Entities;
using GoldenRaspberryAwards.Domain.Repositories;
using GoldenRaspberryAwards.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAwards.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly AwardsContext _context;

    public MovieRepository(AwardsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetWinningMoviesAsync()
    {
        return await _context.Movies.Where(m => m.Winner).Include(m => m.Producer).ToListAsync();
    }

    public async Task AddAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
    }
}