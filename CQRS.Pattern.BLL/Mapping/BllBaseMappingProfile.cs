using AutoMapper;
using CQRS.Pattern.BLL.Models;
using CQRS.Pattern.DAL.Entities;

namespace CQRS.Pattern.BLL.Mapping
{
    public class BllBaseMappingProfile : Profile
    {
        public BllBaseMappingProfile()
        {
            CreateMap<PersonDto, Person>();
            CreateMap<Person, PersonDto>();
        }
    }
}
