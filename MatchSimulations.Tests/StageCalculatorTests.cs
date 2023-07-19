using MatchSimulations.Application;
using MatchSimulations.Domain;

namespace MatchSimulations.Tests
{
    public class StageCalculatorTests
    {
        private readonly StageCalculator stageCalculator;

        public StageCalculatorTests()
        {
            stageCalculator = new StageCalculator();
        }

        [Fact]
        public void SortTeams_ByPoints_ReturnsCorrectOrder()
        {
            // Arrange
            var teams = new List<Team>
        {
            new Team { Name = "Team A", Points = 29, GoalsFor = 45, GoalsAgainst = 30 },
            new Team { Name = "Team B", Points = 25, GoalsFor = 55, GoalsAgainst = 35 },
            new Team { Name = "Team C", Points = 28, GoalsFor = 50, GoalsAgainst = 30 },
            new Team { Name = "Team D", Points = 24, GoalsFor = 40, GoalsAgainst = 25 }
        };

            // Act
            var sortedTeams = stageCalculator.SortTeams(teams);

            // Assert
            Assert.Equal("Team A", sortedTeams[0].Name);
            Assert.Equal("Team C", sortedTeams[1].Name);
            Assert.Equal("Team B", sortedTeams[2].Name);
            Assert.Equal("Team D", sortedTeams[3].Name);
        }

        [Fact]
        public void SortTeams_ByGoalDifference_ReturnsCorrectOrder()
        {
            // Arrange
            var teams = new List<Team>
        {
            new Team { Name = "Team X", Points = 30, GoalsFor = 60, GoalsAgainst = 42 },
            new Team { Name = "Team Y", Points = 30, GoalsFor = 65, GoalsAgainst = 44 },
            new Team { Name = "Team Z", Points = 29, GoalsFor = 70, GoalsAgainst = 52 }
        };

            // Act
            var sortedTeams = stageCalculator.SortTeams(teams);

            // Assert
            Assert.Equal("Team Y", sortedTeams[0].Name);
            Assert.Equal("Team X", sortedTeams[1].Name);
            Assert.Equal("Team Z", sortedTeams[2].Name);
        }

        [Fact]
        public void SortTeams_ByGoalsFor_ReturnsCorrectOrder()
        {
            // Arrange
            var teams = new List<Team>
        {
            new Team { Name = "Team P", Points = 15, GoalsFor = 25, GoalsAgainst = 15 },
            new Team { Name = "Team Q", Points = 15, GoalsFor = 30, GoalsAgainst = 20 },
            new Team { Name = "Team R", Points = 15, GoalsFor = 35, GoalsAgainst = 25 }
        };

            // Act
            var sortedTeams = stageCalculator.SortTeams(teams);

            // Assert
            Assert.Equal("Team R", sortedTeams[0].Name);
            Assert.Equal("Team Q", sortedTeams[1].Name);
            Assert.Equal("Team P", sortedTeams[2].Name);
        }

        [Fact]
        public void SortTeams_WithHeadToHeadLoss_ReturnsTeamsWithSwappedOrder()
        {
            // Arrange
            var teams = new List<Team>
        {
            new Team
            {
                Name = "S",
                Points = 20,
                GoalsFor = 50,
                GoalsAgainst = 30,
                Matches = new List<Match>
                {
                    new Match
                    {
                        AwayTeam = "T",
                        AwayGoals = 3,
                        HomeTeam = "S",
                        HomeGoals = 1
                    }
                }
            },new Team
            {
                Name = "T",
                Points = 20,
                GoalsFor = 50,
                GoalsAgainst = 30,
                Matches = new List<Match>
                {
                    new Match
                    {
                        AwayTeam = "S",
                        AwayGoals = 1,
                        HomeTeam = "T",
                        HomeGoals = 3
                    }
                }
            }
         };

            // Act
            var sortedTeams = stageCalculator.SortTeams(teams);

            // Assert
            Assert.Equal("T", sortedTeams[0].Name);
            Assert.Equal("S", sortedTeams[1].Name);
        }
    }
}
