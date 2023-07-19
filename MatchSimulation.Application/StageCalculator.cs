using MatchSimulations.Application.Abstractios;
using MatchSimulations.Domain;

namespace MatchSimulations.Application
{
    public class StageCalculator : IStageCalculator
    {
        public List<Team> SortTeams(List<Team> teams)
        {
            Team team1 = new();
            Team team2 = new();
            int indexTeam1;
            int indexTeam2;
            var result = teams.OrderByDescending(t => t.Points)
                        .ThenByDescending(t => t.GoalDifference)
                        .ThenByDescending(t => t.GoalsFor)
                        .ThenBy(t => t.GoalsAgainst)
                        .ToList();

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i; j < result.Count - 1; j++)
                {
                    if (result.ElementAt(j).GoalsAgainst == result.ElementAt(j + 1).GoalsAgainst && HeadToHeadResultLosser(result.ElementAt(j), result.ElementAt(j + 1)))
                    {
                        team1 = result.ElementAt(j);
                        team2 = result.ElementAt(j+1);
                        indexTeam1 = result.FindIndex(t => t.Name == result.ElementAt(j).Name);
                        indexTeam2 = result.FindIndex(t => t.Name == result.ElementAt(j+1).Name);
                        result.RemoveAt(indexTeam1);
                        result.Insert(indexTeam1, team2);

                        result.RemoveAt(indexTeam2);
                        result.Insert(indexTeam2, team1);
                    }
                }
            }

            return result;
        }

        private bool HeadToHeadResultLosser(Team team1, Team team2)
        {
            bool team1WonHome = team1.Matches.Any(match => match.HomeTeam == team2.Name && match.HomeGoals > match.AwayGoals);
            bool team1WonAway = team1.Matches.Any(match => match.AwayTeam == team2.Name && match.AwayGoals > match.HomeGoals);

            return team1WonHome || team1WonAway;
        }
    }
}
