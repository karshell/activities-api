using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.Logic.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Activities.Logic.Storage
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _personContext;

        public PersonRepository(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public async Task AddPerson(Person person)
        {
            await _personContext.People.AddAsync(person);

            await _personContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await _personContext.People.ToListAsync();
        }
    }
}
