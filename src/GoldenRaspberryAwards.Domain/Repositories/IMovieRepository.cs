using GoldenRaspberryAwards.Domain.Entities;

namespace GoldenRaspberryAwards.Domain.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetWinningMoviesAsync();
    Task AddAsync(Movie movie);
}