
namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Team> teams;
        static void Main(string[] args)
        {
            teams = new List<Team>();
            try
            {
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] commands = input.Split(";");

                    Command(commands);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        public static void Command(string[] commandArgs)
        {
            string type = commandArgs[0];
            string teamName = commandArgs[1];

            if (type == "Add")
            {
                AddNewTeamPlayer(teamName, commandArgs);
            }
            else if (type == "Remove")
            {
                RemoveTeamPlayer(teamName, commandArgs);
            }
            else if (type == "Rating")
            {
                PrintRating(teamName);
            }
            else if (type == "Team")
            {
                AddNewTeam(teamName);
            }
        }

        static void AddNewTeam(string teamName)
        {
            Team newTeam = new Team(teamName);
            teams.Add(newTeam);
        }
        static void PrintRating(string teamName)
        {
            Team teamToRate = teams.FirstOrDefault(t => t.Name == teamName);

            if (teamToRate == null)
                throw new ArgumentException(string.Format(Exceptions.MissingTeam, teamName));

            Console.WriteLine(teamToRate);
        }

        static void AddNewTeamPlayer(string teamName, string[] commandArgs)
        {
            Team joiningTeam = teams.FirstOrDefault(t => t.Name == teamName);

            if (joiningTeam == null)
                throw new ArgumentException(string.Format(Exceptions.MissingTeam, teamName));

            Player joiningPlayer = NewPlayer(commandArgs);

            joiningTeam.AddPlayer(joiningPlayer);
        }

        static void RemoveTeamPlayer(string teamName, string[] commandArgs)
        {
            string playerName = commandArgs[2];
            Team removingTeam = teams.FirstOrDefault(t => t.Name == teamName);

            if (removingTeam == null)
                throw new ArgumentException(string.Format(Exceptions.MissingTeam, teamName));

            removingTeam.RemovePlayer(playerName);
        }

        static Player NewPlayer(string[] commandArgs)
        {
            string playerName = commandArgs[2];
            int endurance = int.Parse(commandArgs[3]);
            int sprint = int.Parse(commandArgs[4]);
            int dribble = int.Parse(commandArgs[5]);
            int passing = int.Parse(commandArgs[6]);
            int shooting = int.Parse(commandArgs[7]);

            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            return player;
        }
    }
}
