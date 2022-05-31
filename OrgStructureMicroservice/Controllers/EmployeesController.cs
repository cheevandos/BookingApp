using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrgStructureMicroservice.Dto.Export;
using OrgStructureMicroservice.Dto.Import;
using OrgStructureMicroservice.Models;
using OrgStructureMicroservice.Repos.Interfaces;

namespace OrgStructureMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;

        public EmployeesController(
            IEmployeesRepository employeesRepository,
            IMapper mapper
        )
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
        }

        [HttpGet(template: "get/{id}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee? employee = await _employeesRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeReadDto>(employee));
        }

        [HttpGet(template: "getbybranch/{id}")]
        public async Task<IActionResult> GetEmployeesByBranch(int id)
        {
            List<Employee>? employees = 
                await _employeesRepository.GetEmployeesByBranchId(id);

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<EmployeeReadDto>>(employees));
        }

        [HttpGet(template: "getbycompany/{id}")]
        public async Task<IActionResult> GetCompanyEmployees(int id)
        {
            List<Employee>? employees = 
                await _employeesRepository.GetEmployeesByCompanyId(id);

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<EmployeeReadDto>>(employees));
        }

        [HttpPost(template: "create")]
        public async Task<IActionResult> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            Employee newEmployee = _mapper.Map<Employee>(employeeCreateDto);

            try
            {
                await _employeesRepository.CreateEmployee(newEmployee);
                await _employeesRepository.Commit();

                EmployeeReadDto result = _mapper.Map<EmployeeReadDto>(newEmployee);

                return CreatedAtRoute(
                    nameof(GetEmployee),
                    new { id = result.Id },
                    result
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
