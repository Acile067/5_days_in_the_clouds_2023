using Levi9_competition.Models;

namespace Levi9_competition.Services
{
    public class CvsPlayersParser
    {
        private const int NumberOfColumns = 13;

        private static string[] GetLinesFromFile(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        public static List<Player> Parse(string filePath)
        {
            var lines = GetLinesFromFile(filePath);
            return ParseLines(lines);
        }

        public static List<Player> ParseLines(string[] lines, bool skipHeader = true)
        {
            var players = new Dictionary<string, Player>();
            // Skip the first line (header) if required and the file is not empty
            var start = lines.Length > 0 && skipHeader ? 1 : 0;

            foreach (var line in lines[start..])
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var values = line.Split(',');
                if (values.Length != NumberOfColumns) continue;

                var player = new Player
                {
                    FullName = values[0].Trim(),
                    Position = ParsePosition(values[1]),
                    FreeThrowsMade = ParseInt(values[2]),
                    FreeThrowsAttempted = ParseInt(values[3]),
                    TwoPointsMade = ParseInt(values[4]),
                    TwoPointsAttempted = ParseInt(values[5]),
                    ThreePointsMade = ParseInt(values[6]),
                    ThreePointsAttempted = ParseInt(values[7]),
                    Rebounds = ParseInt(values[8]),
                    Blocks = ParseInt(values[9]),
                    Assists = ParseInt(values[10]),
                    Steals = ParseInt(values[11]),
                    Turnovers = ParseInt(values[12]),
                    GamesPlayed = 1
                };

                if (!players.TryAdd(player.FullName, player))
                {
                    players[player.FullName] += player;
                }
            }

            return players.Values.ToList();
        }

        private static PlayerPosition ParsePosition(string? value) =>
        Enum.TryParse<PlayerPosition>(value?.Trim(), out var position) ? position : default;

        private static int ParseInt(string? value) => int.TryParse(value?.Trim(), out var number) ? Math.Abs(number) : 0;
    }
}
