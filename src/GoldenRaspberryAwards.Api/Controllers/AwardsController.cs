using GoldenRaspberryAwards.Application.Services;
using GoldenRaspberryAwards.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoldenRaspberryAwards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AwardsController : ControllerBase
{
    private readonly IAwardService _awardService;

    public AwardsController(IAwardService awardService)
    {
        _awardService = awardService;
    }

    [HttpGet("intervals")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProducerIntervalResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAwardIntervals()
    {
        var result = await _awardService.GetProducerIntervalsAsync();
        return Ok(result);
    }
}