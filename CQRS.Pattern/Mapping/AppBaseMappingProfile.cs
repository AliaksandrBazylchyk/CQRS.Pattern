using AutoMapper;
using CQRS.Pattern.BLL.Models;
using CQRS.Pattern.Models.Requests;

namespace CQRS.Pattern.Mapping
{
    public class AppBaseMappingProfile : Profile
    {
        public AppBaseMappingProfile()
        {
            CreateMap<CreatePersonRequest, PersonDto>();
        }
    }
}
