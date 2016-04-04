namespace TechTalkExample.Common.Contracts
{
    using System.Threading.Tasks;

    using TechTalkExample.Models;

    public interface IRandomPeopleGenerator
    {
        #region Methods

        Person GenerateRandomPerson();

        Task<Person> GenerateRandomPersonAsync();

        #endregion Methods
    }
}