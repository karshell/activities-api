using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Activities.Logic.DataModel;
using Activities.Logic.Exceptions;
using Activities.Logic.Storage;

namespace Activities.Logic.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task AddPerson(Person person)
        {
            //check validity of person model
            if (person == null)
            {
                throw new InvalidPersonException(nameof(Person));
            }

            if (!new EmailAddressAttribute().IsValid(person.Email))
            {
                throw new InvalidPersonException(nameof(person.Email));
            }

            //insert person into repository if valid
            await _personRepository.AddPerson(person);
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            //retrieve all people entities from database
            var results = await _personRepository.GetPeople();

            return results;
        }
    }
}
