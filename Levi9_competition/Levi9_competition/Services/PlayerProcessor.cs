using Levi9_competition.Data;

namespace Levi9_competition.Services
{
    public class PlayerProcessor : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<PlayerProcessor> _logger;

        public PlayerProcessor(IServiceProvider services, ILogger<PlayerProcessor> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var path = Environment.GetEnvironmentVariable("CSV_PLAYER_DATA") ?? "./Data/Players.csv";
            var players = CvsPlayersParser.Parse(path);

            await using var scope = _services.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (players.Count == 0) _logger.LogWarning("No players found in file {Path}", path);
            else _logger.LogInformation("Saving {Count} players to database", players.Count);

            dbContext.AddRange(players);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
