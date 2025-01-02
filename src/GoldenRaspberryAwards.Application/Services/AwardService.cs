using GoldenRaspberryAwards.Domain.Models;
using GoldenRaspberryAwards.Domain.Repositories;

namespace GoldenRaspberryAwards.Application.Services;

public class AwardService : IAwardService
{
    private readonly IMovieRepository _movieRepository;

    public AwardService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<ProducerIntervalResult> GetProducerIntervalsAsync()
    {
        var winners = await _movieRepository.GetWinningMoviesAsync();

        var producersWithWins = winners
            .GroupBy(m => m.Producer.Name)
            .Select(group => new
            {
                Producer = group.Key,
                WinYears = group.OrderBy(m => m.Year).Select(m => m.Year).ToList()
            })
            .Where(g => g.WinYears.Count > 1)
            .ToList();

        if (!producersWithWins.Any())
            throw new InvalidOperationException("No producers with multiple awards found.");

        var intervals = producersWithWins.SelectMany(p =>
            p.WinYears.Zip(p.WinYears.Skip(1), (previous, next) => new ProducerInterval
            {
                Producer = p.Producer,
                Interval = next - previous,
                PreviousWin = previous,
                FollowingWin = next
            })
        ).ToList();

        var minInterval = intervals.Min(i => i.Interval);
        var maxInterval = intervals.Max(i => i.Interval);

        return new ProducerIntervalResult
        {
            Min = intervals.Where(i => i.Interval == minInterval).ToList(),
            Max = intervals.Where(i => i.Interval == maxInterval).ToList()
        };
    }
}
