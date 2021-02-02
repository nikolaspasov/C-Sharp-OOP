using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string command = Console.ReadLine();
                Person newPerson = new Person(command.Split(" ")[0],
                    command.Split(" ")[1],
                    int.Parse(command.Split(" ")[2]),
                   decimal.Parse(command.Split(" ")[3]));
                persons.Add(newPerson);
            }
            Team team = new Team("softuni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FirstTeamCount} players.");
            Console.WriteLine($"Reserve team has {team.SecondTeamCount} players.");

        }
    }
}
