
namespace PersonInfo.Models
{
    using System;

    using Interfaces;

    //Multiple Implementation
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;

        public Citizen(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Citizen(string name, int age, string id, string birthdate)
            : this(name, age)
        {
            Id = id;
            Birthdate = birthdate;
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
                    throw new ArgumentException("Name cannot be empty or white space!");
                name = value;
            }

        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Age must be positive number!");
                age = value;
            }

        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }


        public void SayMyName()
        {
            Console.WriteLine($"Hello! I'm {Name}");
        }
    }
}
