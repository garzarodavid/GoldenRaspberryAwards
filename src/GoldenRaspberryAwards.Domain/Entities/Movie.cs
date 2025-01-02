namespace GoldenRaspberryAwards.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public bool Winner { get; set; }
    public Producer Producer { get; set; }
    public string? Studio { get; set; }
}