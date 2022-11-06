
namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Team
    {
        private string name;
        private List<Player> players;

        public Team()
        {
            players = new List<Player>();
        }

        public Team(string teamName) : this()
        {
            Name = teamName;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(Exceptions.InvalidName);
                name = value;
            }
        }

        public int Rating
            => players.Count > 0 ?
            (int)Math.Round(players.Average(p => p.OverallRating), 0) : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format(Exceptions.MissingPlayer, playerName, Name));
            }

            players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
