
namespace FootballTeamGenerator
{
    using System;

    public class Player
    {
        private string name;

        public Player(string name)
        {
            Name = name;
        }

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Stats = new Statistics(endurance, sprint, dribble, passing, shooting);
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(Exceptions.InvalidName);

                name = value;
            }
        }

        public Statistics Stats { get; set; }

        public double OverallRating
            => (Stats.Endurance + Stats.Sprint + Stats.Dribble + Stats.Passing + Stats.Shooting) / 5.0;
    }
}
