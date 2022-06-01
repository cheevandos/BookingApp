using AutoMapper;
using BookingMicroservice.Dto.Import;
using BookingMicroservice.Models;
using BookingMicroservice.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalImportController : ControllerBase
    {
        private readonly IExternalImportRepository _importRepository;
        private readonly IMapper _mapper;

        public ExternalImportController(
            IExternalImportRepository importRepository,
            IMapper mapper
        )
        {
            _importRepository = importRepository;
            _mapper = mapper;
        }

        [HttpPost(template: "createcompany")]
        public async Task<IActionResult> ImportNewCompany(CompanyCreateDto companyCreateDto)
        {
            CompanyExternal companyExternal = _mapper.Map<CompanyExternal>(companyCreateDto);

            try
            {
                await _importRepository.CreateCompanyExt(companyExternal);
                await _importRepository.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(template: "createbranch")]
        public async Task<IActionResult> ImportNewBranch(BranchCreateDto branchCreateDto)
        {
            BranchExternal branchExternal = _mapper.Map<BranchExternal>(branchCreateDto);

            try
            {
                await _importRepository.CreateBranchExt(branchExternal);
                await _importRepository.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(template: "createemployee")]
        public async Task<IActionResult> ImportNewEmployee(EmployeeCreateDto employeeCreateDto)
        {
            EmployeeExternal employeeExternal = _mapper.Map<EmployeeExternal>(employeeCreateDto);

            try
            {
                await _importRepository.CreateEmployeeExt(employeeExternal);
                await _importRepository.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ImportNewService(ServiceCreateDto serviceCreateDto)
        {
            ServiceExternal serviceExternal = _mapper.Map<ServiceExternal>(serviceCreateDto);

            try
            {
                await _importRepository.CreateServiceExt(serviceExternal);
                await _importRepository.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
