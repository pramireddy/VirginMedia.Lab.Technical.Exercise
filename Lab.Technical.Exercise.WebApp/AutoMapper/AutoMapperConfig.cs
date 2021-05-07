using AutoMapper;
using Lab.Technical.Exercise.DataContracts;
using Lab.Technical.Exercise.Domain.EntityModels;

namespace Lab.Technical.Exercise.WebApp.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Scenario, ScenarioDto>()
                .ForMember(dest => dest.NumberOfMonths, opt => opt.MapFrom(src => src.NumMonths));
        }
    }
}