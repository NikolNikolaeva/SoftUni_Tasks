using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Family family = new Family();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person();
                person.Name = info[0];
                person.Age = int.Parse(info[1]);
                if (person.Age > 30)
                    family.AddMember(person);
            }

            foreach (var item in family.Members)
            {
                Console.WriteLine(item.Name + " - " + item.Age);
            }
        }
    }
}
