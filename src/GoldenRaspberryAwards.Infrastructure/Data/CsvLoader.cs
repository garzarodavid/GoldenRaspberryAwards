using GoldenRaspberryAwards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAwards.Infrastructure.Data
{
    public class CsvLoader
    {
        private readonly AwardsContext _context;

        public CsvLoader(AwardsContext context)
        {
            _context = context;
        }
        public void LoadCsv()
        {

            var filePath = Path.Combine(AppContext.BaseDirectory, "Resources", "movies.csv");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"O arquivo '{filePath}' não foi encontrado.");
            }
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var columns = line.Split(';');
                var producers = columns[3].Replace(" and ", ",").Split(',').Select(p => p.Trim()).ToArray();
                bool isWinner = columns.Length > 4 && columns[4].Trim().ToLower() == "yes";
                var studio = columns[2];

                foreach (var producerName in producers)
                {
                    var producer = _context.Producers.FirstOrDefault(p => p.Name == producerName) ?? new Producer { Name = producerName };
                    if (_context.Entry(producer).State == EntityState.Detached)
                    {
                        _context.Producers.Add(producer);
                    }

                    var movie = new Movie
                    {
                        Title = columns[1],
                        Year = int.Parse(columns[0]),
                        Winner = isWinner,
                        Studio = studio,
                        Producer = producer
                    };

                    _context.Movies.Add(movie);
                }
            }
            _context.SaveChanges();
        }
    }
}