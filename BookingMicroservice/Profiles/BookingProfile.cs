using AutoMapper;
using BookingMicroservice.Dto.Export;
using BookingMicroservice.Dto.Import;
using BookingMicroservice.Models;

namespace BookingMicroservice.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingCreateDto, Booking>()
                .ForMember(
                    dest => dest.BranchExternalId, 
                    options => options.MapFrom(src => src.BranchId)
                )
                .ForMember(
                    dest => dest.CompanyExternalId,
                    options => options.MapFrom(src => src.CompanyId)
                )
                .ForMember(
                    dest => dest.EmployeeExternalId,
                    options => options.MapFrom(src => src.EmployeeId)
                )
                .ForMember(
                    dest => dest.Services,
                    options => options.MapFrom(src => 
                        src.Services != null ? 
                        src.Services.Select(servId => new ServiceExternal { ExternalId = servId }) :
                        null
                    )
                );

            CreateMap<Booking, CustomerBookingDetailsDto>()
                .ForMember(
                    dest => dest.BranchAddress,
                    options => options.MapFrom(src =>
                        src.BranchExternal != null ?
                        src.BranchExternal.Address :
                        string.Empty
                    )
                )
                .ForMember(
                    dest => dest.CompanyName,
                    options => options.MapFrom(src =>
                        src.CompanyExternal != null ?
                        src.CompanyExternal.Name :
                        string.Empty
                    )
                )
                .ForMember(
                    dest => dest.EmployeeName,
                    options => options.MapFrom(src =>
                        src.EmployeeExternal != null ?
                        $"{src.EmployeeExternal.FirstName} {src.EmployeeExternal.LastName}" :
                        string.Empty
                    )
                );

            CreateMap<Booking, CustomerBookingShortInfoDto>()
                .ForMember(
                    dest => dest.BranchAddress,
                    options => options.MapFrom(src => 
                        src.BranchExternal != null ?
                        src.BranchExternal.Address :
                        string.Empty
                    )
                )
                .ForMember(
                    dest => dest.CompanyName,
                    options => options.MapFrom(src => 
                        src.CompanyExternal != null ?
                        src.CompanyExternal.Name :
                        string.Empty
                    )
                );

            CreateMap<Booking, EmployeeBookingDetailsDto>();
            CreateMap<Booking, EmployeeBookingShortInfoDto>();
        }
    }
}
