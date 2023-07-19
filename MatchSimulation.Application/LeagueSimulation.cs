using MatchSimulations.Application.Abstractios;
using MatchSimulations.Domain;

namespace MatchSimulations.Application
{
    public class LeagueSimulation : ILeagueSimulation
    {
        private readonly IMatchSimulation _matchSimulation;
        private readonly IStageCalculator _stageCalculator;

        private List<Team> _teams = new List<Team>();

        public LeagueSimulation(IMatchSimulation matchSimulation, IStageCalculator stageCalculator)
        {
            _matchSimulation = matchSimulation;
            _stageCalculator = stageCalculator;
        }

        public List<Team> SimulateLeague(List<Team> teams)
        {
            Match match;
            for (int i = 0; i < teams.Count-1; i++)
            {
                for (int j = i+1; j < teams.Count; j++)
                {
                    _matchSimulation.SimulateMatch(teams.ElementAt(i), teams.ElementAt(j));
                }
            }
            return _stageCalculator.SortTeams(teams);
        }
    }
}
