using System.Collections.Generic;
using System.Threading.Tasks;
using Activities.Logic.DataModel;

namespace Activities.Logic.Services
{
    public interface IPersonService
    {
        Task AddPerson(Person person);

        Task<IEnumerable<Person>> GetPeople();
    }
}
