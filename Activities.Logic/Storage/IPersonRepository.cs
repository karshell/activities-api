using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.Logic.DataModel;

namespace Activities.Logic.Storage
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeople();

        Task AddPerson(Person person);
    }
}
