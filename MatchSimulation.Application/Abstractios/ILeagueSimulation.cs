using MatchSimulations.Domain;

namespace MatchSimulations.Application.Abstractios
{
    public interface ILeagueSimulation
    {
        public List<Team> SimulateLeague(List<Team> teams);

    }
}
