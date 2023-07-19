using MatchSimulations.Application.Abstractios;
using MatchSimulations.Domain;

namespace MatchSimulations.Application
{
    public class MatchSimulation : IMatchSimulation
    {
        public void SimulateMatch(Team homeTeam, Team awayTeam)
        {
            Random random = new Random();

            double homeExpectedGoals = homeTeam.Strength * random.NextDouble();
            double awayExpectedGoals = awayTeam.Strength * random.NextDouble();

            int homeGoals = PoissonDistribution(homeExpectedGoals);
            int awayGoals = PoissonDistribution(awayExpectedGoals);

            homeTeam.GoalsFor += homeGoals;
            homeTeam.GoalsAgainst += awayGoals;
            homeTeam.MatchesPlayed++;

            awayTeam.GoalsFor += awayGoals;
            awayTeam.GoalsAgainst += homeGoals;
            awayTeam.MatchesPlayed++;

            if (homeGoals > awayGoals)
            {
                homeTeam.Wins++;
                homeTeam.Points += 3;
                awayTeam.Losses++;
            }
            else if (homeGoals < awayGoals)
            {
                awayTeam.Wins++;
                awayTeam.Points += 3;
                homeTeam.Losses++;
            }
            else
            {
                homeTeam.Draws++;
                homeTeam.Points += 1;
                awayTeam.Draws++;
                awayTeam.Points += 1;
            }
            homeTeam.Matches.Add(new Match
            {
                HomeTeam = homeTeam.Name,
                AwayTeam = awayTeam.Name,
                HomeGoals = homeGoals,
                AwayGoals = awayGoals
            });

            awayTeam.Matches.Add(new Match
            {
                HomeTeam = homeTeam.Name,
                AwayTeam = awayTeam.Name,
                HomeGoals = homeGoals,
                AwayGoals = awayGoals
            });
        }

        private int PoissonDistribution(double expectedGoals)
        {
            Random random = new Random();

            double L = Math.Exp(-expectedGoals);
            int k = 0;
            double p = 1.0;

            do
            {
                k++;
                p *= random.NextDouble();
            }
            while (p > L);

            return k - 1;
        }
    }
}
