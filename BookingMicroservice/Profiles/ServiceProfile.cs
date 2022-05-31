using AutoMapper;
using BookingMicroservice.Dto.Export;
using BookingMicroservice.Dto.Import;
using BookingMicroservice.Models;

namespace BookingMicroservice.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceExternal, ServiceReadDto>()
                .ForMember(
                    dest => dest.Name,
                    options => options.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Duration,
                    options => options.MapFrom(src => src.Duration)
                )
                .ForMember(
                    dest => dest.Price,
                    options => options.MapFrom(src => src.Price)
                );

            CreateMap<ServiceCreateDto, ServiceExternal>()
                .ForMember(
                    dest => dest.ExternalId,
                    options => options.MapFrom(src => src.ExternalId)
                )
                .ForMember(
                    dest => dest.Name,
                    options => options.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Duration,
                    options => options.MapFrom(src => src.Duration)
                )
                .ForMember(
                    dest => dest.Price,
                    options => options.MapFrom(src => src.Price)
                );
        }
    }
}
