using AutoMapper;
using OrgStructureMicroservice.Dto.Export;
using OrgStructureMicroservice.Dto.Import;
using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeReadDto>()
                .ForMember(
                    dest => dest.Id,
                    options => options.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.FirstName,
                    options => options.MapFrom(src => src.FirstName)
                )
                .ForMember(
                    dest => dest.LastName,
                    options => options.MapFrom(src => src.LastName)
                )
                .ForMember(
                    dest => dest.Position,
                    options => options.MapFrom(src => src.Position)
                );

            CreateMap<EmployeeCreateDto, Employee>()
                .ForMember(
                    dest => dest.BranchId,
                    options => options.MapFrom(src => src.BranchId)
                )
                .ForMember(
                    dest => dest.FirstName,
                    options => options.MapFrom(src => src.FirstName)
                )
                .ForMember(
                    dest => dest.LastName,
                    options => options.MapFrom(src => src.LastName)
                )
                .ForMember(
                    dest => dest.Position,
                    options => options.MapFrom(src => src.Position)
                );
        }
    }
}