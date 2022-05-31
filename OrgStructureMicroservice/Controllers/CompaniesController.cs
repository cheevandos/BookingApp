using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrgStructureMicroservice.Dto.Export;
using OrgStructureMicroservice.Models;
using OrgStructureMicroservice.Repos.Interfaces;

namespace OrgStructureMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IMapper _mapper;

        public CompaniesController(
            ICompaniesRepository companiesRepository,
            IMapper mapper
        )
        {
            _companiesRepository = companiesRepository;
            _mapper = mapper;
        }

        [HttpGet(template: "getall")]
        public async Task<IActionResult> GetAllCompanies()
        {
            List<Company>? companies = 
                await _companiesRepository.GetAllCompanies();

            if (companies == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CompanyReadDto>>(companies));
        }

        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            Company? company = await _companiesRepository.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CompanyReadDto>(company));
        }
    }
}
