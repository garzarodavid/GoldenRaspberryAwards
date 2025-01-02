namespace GoldenRaspberryAwards.Domain.Models;

/// <summary>
/// Contém os resultados dos intervalos de premiações mínimos e máximos para os produtores.
/// </summary>
public class ProducerIntervalResult
{
    /// <summary>
    /// Lista dos intervalos mínimos de premiações.
    /// </summary>
    public List<ProducerInterval> Min { get; set; }

    /// <summary>
    /// Lista dos intervalos máximos de premiações.
    /// </summary>
    public List<ProducerInterval> Max { get; set; }
}