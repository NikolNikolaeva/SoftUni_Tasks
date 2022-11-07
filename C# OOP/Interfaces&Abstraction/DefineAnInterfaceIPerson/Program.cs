
namespace PersonInfo
{
    using System;

    using Models.Interfaces;
    using PersonInfo.Models;

    public class StartUp
    {

        static void Main(string[] args)
        {
            //Interface and Abstraction  

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);  //type IPerson
            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Age: " + person.Age);

            Citizen otherPerson = new Citizen(name, age);
            otherPerson.SayMyName();  //type Citizen (method in Citizen)

            //Multiple Implementation

            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);
            Console.WriteLine("Id: " + identifiable.Id);
            Console.WriteLine("Birthdate: " + birthable.Birthdate);
        }
    }
}
