using Cinema.Common;

internal class Program
{
    private static async Task Main()
    {
        var service = new CinemaService();

        Console.WriteLine("=== Cinema Async CRUD Demo ===");

        var tasks = Enumerable.Range(1, 10).Select(i =>
        {
            var session = new CinemaSession
            {
                MovieTitle = $"Movie {i}",
                StartTime = DateTime.Now.AddHours(i),
                AvailableSeats = 100 + i
            };

            return service.CreateSessionAsync(session);
        });

        await Task.WhenAll(tasks);

        Console.WriteLine("Created 10 sessions in parallel.");

        var all = await service.GetAllSessionsAsync();
        foreach (var s in all)
            Console.WriteLine(s);

        Console.WriteLine("Done. Press any key to exit.");
        Console.ReadKey();
    }
}
