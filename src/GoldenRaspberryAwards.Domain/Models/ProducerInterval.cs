namespace GoldenRaspberryAwards.Domain.Models;

/// <summary>
/// Representa um intervalo de premiações para um produtor.
/// </summary>
public class ProducerInterval
{
    /// <summary>
    /// Nome do produtor.
    /// </summary>
    public string Producer { get; set; }

    /// <summary>
    /// Intervalo de anos entre as premiações.
    /// </summary>
    public int Interval { get; set; }

    /// <summary>
    /// Ano da premiação anterior.
    /// </summary>
    public int PreviousWin { get; set; }

    /// <summary>
    /// Ano da premiação seguinte.
    /// </summary>
    public int FollowingWin { get; set; }
}