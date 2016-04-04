namespace TechTalkExample.RandomPeopleApi.Controllers
{
    using System.Web.Http;

    using RandomNameGeneratorLibrary;

    using TechTalkExample.Models;

    public class RandomPeopleApiController : ApiController
    {
        #region Methods

        [HttpPost]
        [Route("api/random-people")]
        public IHttpActionResult GetNewRandomPerson()
        {
            var nameGenerator = new PersonNameGenerator();
            var person = new Person() { FirstName = nameGenerator.GenerateRandomFirstName(), LastName = nameGenerator.GenerateRandomLastName() };
            return this.Ok(person);
        }

        #endregion Methods
    }
}