using MatchSimulations.Application;
using MatchSimulations.Application.Abstractios;
using MatchSimulations.Domain;
using Moq;

namespace MatchSimulations.Tests
{
    public class LeagueSimulationTests
    {
        [Fact]
        public void SimulateLeague_ShouldCallSortTeamsOnce()
        {
            // Arrange
            var teams = new List<Team>
        {
            new Team { Name = "Team A", Points = 0, GoalsFor = 0, GoalsAgainst = 0 },
            new Team { Name = "Team B", Points = 0, GoalsFor = 0, GoalsAgainst = 0 },
            new Team { Name = "Team C", Points = 0, GoalsFor = 0, GoalsAgainst = 0 }
        };

            var matchSimulationMock = new Mock<IMatchSimulation>();
            matchSimulationMock.Setup(ms => ms.SimulateMatch(It.IsAny<Team>(), It.IsAny<Team>()));

            var stageCalculatorMock = new Mock<IStageCalculator>();
            stageCalculatorMock.Setup(sc => sc.SortTeams(It.IsAny<List<Team>>())).Returns(teams);

            var leagueSimulation = new LeagueSimulation(matchSimulationMock.Object, stageCalculatorMock.Object);

            // Act
            var result = leagueSimulation.SimulateLeague(teams);

            // Assert
            matchSimulationMock.Verify(ms => ms.SimulateMatch(It.IsAny<Team>(), It.IsAny<Team>()), Times.Exactly(teams.Count * (teams.Count - 1) / 2));

            stageCalculatorMock.Verify(sc => sc.SortTeams(It.IsAny<List<Team>>()), Times.Once);
        }
    }
}
