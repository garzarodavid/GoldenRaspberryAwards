using GoldenRaspberryAwards.Domain.Models;

namespace GoldenRaspberryAwards.Application.Services;

public interface IAwardService
{
    Task<ProducerIntervalResult> GetProducerIntervalsAsync();
}