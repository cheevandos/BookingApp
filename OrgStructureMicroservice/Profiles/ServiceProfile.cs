using AutoMapper;
using OrgStructureMicroservice.Dto.Export;
using OrgStructureMicroservice.Dto.Import;
using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile(GlobalOptions globalOptions)
        {
            CreateMap<Service, ServiceReadDto>()
                .ForMember(
                    dest => dest.Id,
                    options => options.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    options => options.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Duration,
                    options => options
                        .MapFrom(src => src.TimeUnits * globalOptions.TimeUnitValue)
                )
                .ForMember(
                    dest => dest.Price,
                    options => options.MapFrom(src => src.Price)
                );

            CreateMap<ServiceCreateDto, Service>()
                .ForMember(
                    dest => dest.CompanyId,
                    options => options.MapFrom(src => src.CompanyId)
                )
                .ForMember(
                    dest => dest.Name,
                    options => options.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Price,
                    options => options.MapFrom(src => src.Price)
                )
                .ForMember(
                    dest => dest.TimeUnits,
                    options => options.MapFrom(src => (int)(src.Price / globalOptions.TimeUnitValue))
                );
        }
    }
}
