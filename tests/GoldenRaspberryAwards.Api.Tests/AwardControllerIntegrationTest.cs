using GoldenRaspberryAwards.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

public class AwardControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions options;

    public AwardControllerIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();

        options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true
        };
    }

    [Fact]
    public async Task TestGetAwardIntervals()
    {
        var response = await _client.GetAsync("/awards/intervals");
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        var retorno = JsonSerializer.Deserialize<ProducerIntervalResult>(result, options);

        Assert.NotNull(retorno.Min);
        Assert.NotNull(retorno.Max);
        Assert.NotEmpty(retorno.Min);
        Assert.NotEmpty(retorno.Max);
    }
}