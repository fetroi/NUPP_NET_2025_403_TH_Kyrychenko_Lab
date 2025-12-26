using Cinema.Common.Models;
using Cinema.Common.Services;

Console.WriteLine("=== CRUD DEMO (Cinema: Movies) ===");

var movieService = new InMemoryCrudService<Movie>();

var movie = new Movie
{
    Id = Guid.NewGuid(),
    Title = "Interstellar",
    Genre = "Sci-Fi",
    DurationMinutes = 169,
    Rating = 8.6
};

movieService.Create(movie);
Console.WriteLine("Movie created");

var loaded = movieService.Read(movie.Id);
Console.WriteLine($"Read movie: {loaded.Title} | {loaded.Genre} | {loaded.DurationMinutes} min | Rating: {loaded.Rating}");

Console.WriteLine("All movies:");
foreach (var m in movieService.ReadAll())
{
    Console.WriteLine($"- {m.Title} ({m.Genre}), {m.DurationMinutes} min, Rating: {m.Rating}");
}

loaded.Rating = 9.0;
movieService.Update(loaded);
Console.WriteLine("Movie updated");

movieService.Remove(movie.Id);
Console.WriteLine("Movie removed");

Console.WriteLine("=== END ===");
