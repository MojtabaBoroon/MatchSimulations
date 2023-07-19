using MatchSimulations.Domain;

namespace MatchSimulations.Application.Abstractios
{
    public interface IMatchSimulation
    {
        public void SimulateMatch(Team homeTeam, Team awayTeam);
    }
}
