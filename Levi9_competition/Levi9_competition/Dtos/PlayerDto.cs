using Levi9_competition.Models;

namespace Levi9_competition.Dtos
{
    public record ShootingStats(double Attempts, double Made, double ShootingPercentage);

    public record TraditionalStats(
        ShootingStats FreeThrows,
        ShootingStats TwoPoints,
        ShootingStats ThreePoints,
        double Points,
        double Rebounds,
        double Blocks,
        double Assists,
        double Steals,
        double Turnovers
    );

    public record AdvancedStats(
        double Valorization,
        double EffectiveFieldGoalPercentage,
        double TrueShootingPercentage,
        double HollingerAssistRatio
    );
    public class PlayerDto
    {
        public string PlayerName { get; init; }
        public int GamesPlayed { get; init; }
        public TraditionalStats Traditional { get; init; }
        public AdvancedStats Advanced { get; init; }

        public PlayerDto(Player player)
        {
            PlayerName = player.FullName;
            GamesPlayed = player.GamesPlayed;
            Traditional = new TraditionalStats(
                new ShootingStats(
                    Average(player.FreeThrowsAttempted),
                    Average(player.FreeThrowsMade),
                    Rounded(player.FreeThrowPercentage)
                ),
                new ShootingStats(
                    Average(player.TwoPointsAttempted),
                    Average(player.TwoPointsMade),
                    Rounded(player.TwoPointsPercentage)
                ),
                new ShootingStats(
                    Average(player.ThreePointsAttempted),
                    Average(player.ThreePointsMade),
                    Rounded(player.ThreePointsPercentage)
                ),
                Average(player.Points),
                Average(player.Rebounds),
                Average(player.Blocks),
                Average(player.Assists),
                Average(player.Steals),
                Average(player.Turnovers)
            );
            Advanced = new AdvancedStats(
                Average(player.Valorization),
                Rounded(player.EffectiveFieldGoalPercentage),
                Rounded(player.TrueShootingPercentage),
                Rounded(player.HollingerAssistRatio)
            );
        }

        private double Rounded(double value) => Math.Round(value, 1);
        private double Average(double value) => Rounded(value / GamesPlayed);
    }
}
