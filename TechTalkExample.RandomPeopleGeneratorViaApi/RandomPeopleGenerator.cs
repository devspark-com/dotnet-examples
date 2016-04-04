namespace TechTalkExample.RandomPeopleGeneratorViaApi
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using TechTalkExample.Common.Contracts;
    using TechTalkExample.Models;
    using System.Configuration;

    public class RandomPeopleGenerator : IRandomPeopleGenerator
    {
        public Person GenerateRandomPerson()
        {
            return this.GenerateRandomPersonAsync().Result;
        }

        public async Task<Person> GenerateRandomPersonAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["TechTalkExample.RandomPeopleGeneratorApiEndpoint"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync("/api/random-people", null);
                if (response.IsSuccessStatusCode)
                {
                    Person person = await response.Content.ReadAsAsync<Person>();
                    return person;
                }
                else
                {
                    throw new Exception("Couldn\'t connect to the random people generator API");
                }
            }
        }
    }
}
