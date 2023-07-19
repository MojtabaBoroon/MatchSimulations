using MatchSimulations.Application;
using MatchSimulations.Domain;

namespace MatchSimulations.Tests
{
    public class MatchSimulationTests
    {
        [Theory]
        [InlineData("Home Team", 10, 0, 0, 0, 0, 0, 0, 0, "Away Team", 10, 0, 0, 0, 0, 0, 0, 0 )]
        [InlineData("Boca Juniors", 7, 6, 18, 5, 1, 0, 15, 6, "River Plate", 9, 6, 21, 7, 0, 0, 20, 8)]
        [InlineData("Barcelona", 1, 5, 7, 2, 1, 2, 8, 6, "Real Madrid", 2, 5, 10, 3, 1, 1, 9, 5)]
        [InlineData("Manchester United", 3, 4, 10, 3, 0, 1, 10, 3, "Liverpool", 2, 4, 7, 2, 1, 1, 6, 5)]
        [InlineData("Juventus", 4, 3, 12, 4, 0, 0, 14, 3, "AC Milan", 5, 3, 15, 5, 0, 0, 15, 2)]
        [InlineData("Bayern Munich", 6, 5, 18, 5, 0, 0, 20, 2, "Borussia Dortmund", 7, 5, 21, 7, 0, 0, 21, 4)]
        [InlineData("Chelsea", 8, 6, 20, 6, 0, 0, 25, 5, "Arsenal", 9, 6, 27, 9, 0, 0, 30, 3)]
        [InlineData("Paris Saint-Germain", 10, 8, 24, 7, 1, 0, 30, 6, "Olympique Marseille", 10, 8, 27, 8, 0, 1, 32, 5)]
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
