using MatchSimulations.Application;
using MatchSimulations.Domain;

namespace MatchSimulations.Tests
{
    public class MatchSimulationTests
    {
        [Theory]
        [InlineData("Home Team", 10, 0, 0, 0, 0, 0, 0, 0, "Away Team", 10, 0, 0, 0, 0, 0, 0, 0 )]
        [InlineData("Barcelona", 20, 5, 15, 5, 0, 0, 20, 3, "Real Madrid", 18, 5, 12, 4, 1, 0, 15, 6)]
        [InlineData("Manchester United", 16, 8, 24, 7, 0, 1, 22, 5, "Liverpool", 17, 8, 27, 8, 0, 0, 28, 10)]
        [InlineData("Juventus", 14, 6, 18, 4, 1, 1, 13, 8, "AC Milan", 14, 6, 18, 4, 1, 1, 10, 5)]
        [InlineData("Bayern Munich", 22, 10, 30, 9, 0, 1, 32, 7, "Borussia Dortmund", 20, 10, 30, 9, 0, 1, 28, 10)]
        [InlineData("Chelsea", 18, 7, 21, 6, 1, 0, 22, 9, "Arsenal", 16, 7, 20, 5, 2, 0, 20, 12)]
        [InlineData("Manchester City", 23, 9, 30, 9, 0, 0, 30, 5, "Tottenham Hotspur", 20, 9, 27, 8, 1, 0, 25, 12)]
        [InlineData("Paris Saint-Germain", 22, 10, 31, 10, 0, 0, 35, 6, "Olympique Marseille", 18, 10, 23, 7, 2, 1, 20, 11)]
        [InlineData("Atletico Madrid", 20, 8, 27, 8, 0, 0, 25, 4, "Real Betis", 15, 8, 21, 5, 2, 1, 18, 14)]
        [InlineData("FC Porto", 16, 5, 15, 4, 1, 0, 12, 7, "SL Benfica", 15, 5, 12, 3, 2, 0, 10, 8)]
        [InlineData("Boca Juniors", 17, 6, 18, 5, 1, 0, 15, 6, "River Plate", 19, 6, 21, 7, 0, 0, 20, 8)]
        public void SimulateMatch_ValidTeamsInformation_UpdateTeamStatisticsCorrectly(
            string homeTeamName, int homeTeamStrength, int homeTeamMatchesPlayed, int homeTeamPoints, int homeTeamWins, int homeTeamLosses, int homeTeamDraws, int homeTeamGoalsFor, int homeTeamGoalsAgainst,
            string awayTeamName, int awayTeamStrength, int awayTeamMatchesPlayed, int awayTeamPoints, int awayTeamWins, int awayTeamLosses, int awayTeamDraws, int awayTeamGoalsFor, int awayTeamGoalsAgainst)
        {
            // Arrange
            var homeTeam = new Team
            {
                Name = homeTeamName,
                Strength = homeTeamStrength,
                MatchesPlayed = homeTeamMatchesPlayed,
                Points = homeTeamPoints,
                Wins = homeTeamWins,
                Losses = homeTeamLosses,
                Draws = homeTeamDraws,
                GoalsFor = homeTeamGoalsFor,
                GoalsAgainst = homeTeamGoalsAgainst
            };

            var awayTeam = new Team
            {
                Name = awayTeamName,
                Strength = awayTeamStrength,
                MatchesPlayed = awayTeamMatchesPlayed,
                Points = awayTeamPoints,
                Wins = awayTeamWins,
                Losses = awayTeamLosses,
                Draws = awayTeamDraws,
                GoalsFor = awayTeamGoalsFor,
                GoalsAgainst = awayTeamGoalsAgainst
            };
            var matchSimulation = new MatchSimulation();

            // Act
            matchSimulation.SimulateMatch(homeTeam, awayTeam);

            // Assert
            Assert.Equal(homeTeam.MatchesPlayed, homeTeamMatchesPlayed + 1);
            Assert.Equal(awayTeam.MatchesPlayed, awayTeamMatchesPlayed + 1);
            Assert.Equal(awayTeam.GoalsFor - awayTeamGoalsFor, homeTeam.GoalsAgainst - homeTeamGoalsAgainst);
            Assert.Equal(awayTeam.GoalsAgainst - awayTeamGoalsAgainst, homeTeam.GoalsFor - homeTeamGoalsFor);
            Assert.Equal(awayTeam.Wins - awayTeamWins, homeTeam.Losses - homeTeamLosses);
            Assert.Equal(awayTeam.Losses - awayTeamLosses, homeTeam.Wins - homeTeamWins);
            Assert.Equal(awayTeam.Draws - awayTeamDraws, homeTeam.Draws - homeTeamDraws);
            Assert.InRange(homeTeam.Points + awayTeam.Points, homeTeamPoints + awayTeamPoints + 2, homeTeamPoints + awayTeamPoints + 3);
        }
    }
}
