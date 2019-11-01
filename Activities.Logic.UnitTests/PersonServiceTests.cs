using System.Threading.Tasks;
using Activities.Logic.DataModel;
using Activities.Logic.Exceptions;
using Activities.Logic.Services;
using Activities.Logic.Storage;
using Moq;
using Xunit;

namespace Activities.Logic.UnitTests
{
    public class PersonServiceTests
    {
        private readonly Mock<IPersonRepository> _personRepositoryMock;
        private readonly IPersonService _personService;

        public PersonServiceTests()
        {
            _personRepositoryMock = new Mock<IPersonRepository>();
            _personService = new PersonService(_personRepositoryMock.Object);
        }

        [Fact]
        public async Task AddPerson_NullPersonRequest_ThrowsInvalidPersonException()
        {
            Person person = null;

            await Assert.ThrowsAsync<InvalidPersonException>(async () => await _personService.AddPerson(person));

        }

        [Fact]
        public async Task AddPerson_InvalidEmail_ThrowsInvalidPersonException()
        {
            Person person = CreateTestPerson();
            person.Email = "invalidemail";

            await Assert.ThrowsAsync<InvalidPersonException>(async () => await _personService.AddPerson(person));
        }

        [Fact]
        public async Task AddPerson_ValidPerson_StoresPerson()
        {
            Person person = CreateTestPerson();

            await _personService.AddPerson(person);

            _personRepositoryMock.Verify(r => r.AddPerson(person), Times.Once);
        }

        private Person CreateTestPerson()
        {
            return  new Person {
                FirstName = "FirstName",
                LastName = "LastName",
                Activity = "Test Activity",
                Comments = "Comment 1",
                Email = "test@test.com"
            };
        }
    }
}
