using AutoMapper;
using OrgStructureMicroservice.Dto.Export;
using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyReadDto>()
                .ForMember(
                    dest => dest.Id,
                    options => options.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    options => options.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Type,
                    options => options.MapFrom(src => src.Type)
                );
        }
    }
}
