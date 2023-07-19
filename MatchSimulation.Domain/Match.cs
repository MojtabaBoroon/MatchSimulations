namespace MatchSimulations.Domain
{
    public class Match
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public Match()
        {
            HomeGoals = 0;
            AwayGoals = 0;
        }
    }
}
