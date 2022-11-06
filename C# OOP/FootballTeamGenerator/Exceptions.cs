using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class Exceptions
    {
        public const string InvalidStatics = "{0} should be between 0 and 100.";

        public const string InvalidName = "A name should not be empty.";

        public const string MissingPlayer = "Player {0} is not in {1} team.";

        public const string MissingTeam = "Team {0} does not exist.";
    }
}
