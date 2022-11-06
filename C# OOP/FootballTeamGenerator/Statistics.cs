
namespace FootballTeamGenerator
{
    using System;

    public class Statistics
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private object p;

        private bool isStatInvalid(int value) => value < 0 || value > 100;

        public Statistics(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public Statistics(int endurance, object p)
        {
            this.endurance = endurance;
            this.p = p;
        }

        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                if (isStatInvalid(value))
                    throw new ArgumentException(string.Format(Exceptions.InvalidStatics, nameof(Endurance)));
                endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                if (isStatInvalid(value))
                    throw new ArgumentException(string.Format(Exceptions.InvalidStatics, nameof(Sprint)));
                sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                if (isStatInvalid(value))
                    throw new ArgumentException(string.Format(Exceptions.InvalidStatics, nameof(Dribble)));
                dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                if (isStatInvalid(value))
                    throw new ArgumentException(string.Format(Exceptions.InvalidStatics, nameof(Passing)));
                passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                if (isStatInvalid(value))
                    throw new ArgumentException(string.Format(Exceptions.InvalidStatics, nameof(Shooting)));
                shooting = value;
            }
        }

    }

}
