namespace TechTalkExample.Application1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TechTalkExample.Common.Contracts;
    using TechTalkExample.Models;
    using TechTalkExample.RandomPeopleGeneratorViaApi;

    class Program
    {
        #region Fields

        static readonly IRandomPeopleGenerator RandomPeopleGenerator = new RandomPeopleGenerator();

        #endregion Fields

        #region Methods

        static void Main(string[] args)
        {
            var people = new List<Person>();

            var times = 100;

            Parallel.For(0, times, (x) =>
            {
                var person = RandomPeopleGenerator.GenerateRandomPerson();
                lock (people)
                {
                    people.Add(person);
                }
            });

            // Calling GenerateRandomPerson asynchronously
            var getNewPerson = RandomPeopleGenerator.GenerateRandomPersonAsync();

            // I still can do stuff
            Console.WriteLine("Hello! We are generating one more random person...");

            // The .Result method will block and wait until the result is ready.
            people.Add(getNewPerson.Result);

            var totalPeople = people.Count();
            var numberOfPeopleWhoseFirstNameStartsWithL = people.AsParallel().Where(x => x.FirstName.StartsWith("L")).Count();
            Console.WriteLine($"Found {numberOfPeopleWhoseFirstNameStartsWithL} out of {totalPeople} people whose first name starts with L.");

            Console.ReadKey();
        }

        #endregion Methods
    }
}