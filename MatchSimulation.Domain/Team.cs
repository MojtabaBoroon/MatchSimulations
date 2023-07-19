namespace MatchSimulations.Domain
{
    public class Team
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int MatchesPlayed { get; set; }
        public int Strength { get; set; }
        public List<Match> Matches { get; set; } = new List<Match>();

        public Team()
        {

        }
        public Team(string name, int strength)
        {
            Name = name;
            Points = 0;
            GoalsFor = 0;
            GoalsAgainst = 0;
            Wins = 0;
            Draws = 0;
            Losses = 0;
            MatchesPlayed = 0;
            Strength = strength;
        }
    }
}
