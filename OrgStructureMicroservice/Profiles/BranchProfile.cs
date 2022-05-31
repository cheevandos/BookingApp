using AutoMapper;
using OrgStructureMicroservice.Dto.Export;
using OrgStructureMicroservice.Dto.Import;
using OrgStructureMicroservice.Models;

namespace OrgStructureMicroservice.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchReadDto>()
                .ForMember(
                    dest => dest.Id,
                    options => options.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Address,
                    options => options.MapFrom(src => src.Address)
                );

            CreateMap<BranchCreateDto, Branch>()
                .ForMember(
                    dest => dest.Address,
                    options => options.MapFrom(src => src.Address)
                )
                .ForMember(
                    dest => dest.CompanyId,
                    options => options.MapFrom(src => src.CompanyId)
                );
        }
    }
}
