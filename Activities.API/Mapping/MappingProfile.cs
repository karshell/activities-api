using Activities.DTO;
using Activities.Logic.DataModel;
using AutoMapper;

namespace Activities.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDto, Person>();
        }
    }
}
