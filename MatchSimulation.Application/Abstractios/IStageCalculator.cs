using MatchSimulations.Domain;

namespace MatchSimulations.Application.Abstractios
{
    public interface IStageCalculator
    {
        public List<Team> SortTeams(List<Team> teams);
    }
}
