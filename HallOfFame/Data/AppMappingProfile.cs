using AutoMapper;
using HallOfFame.Data;

namespace HallOfFame.Data
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Models.Skill, Transfer.Skill>().ReverseMap();
            CreateMap<Models.Person, Transfer.Person>().ReverseMap();
        }
    }
}
