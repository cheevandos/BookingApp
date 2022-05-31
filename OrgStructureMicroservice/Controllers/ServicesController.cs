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
    public class ServicesController : ControllerBase
    {
        private readonly IServicesRepository _servicesRepository;
        private readonly IMapper _mapper;

        public ServicesController(
            IServicesRepository servicesRepository,
            IMapper mapper
        )
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }

        [HttpGet(template: "getbycompany/{id}")]
        public async Task<IActionResult> GetCompanyServices(int id)
        {
            List<Service>? services = await _servicesRepository.GetByCompanyId(id);

            if (services == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ServiceReadDto>>(services));
        }

        [HttpGet(template: "getbyemployee/{id}")]
        public async Task<IActionResult> GetEmployeeServices(int id)
        {
            List<Service>? services = await _servicesRepository.GetByEmployeeId(id);

            if (services == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ServiceReadDto>>(services));
        }

        [HttpGet(template: "get/{id}", Name = "GetService")]
        public async Task<IActionResult> GetService(int id)
        {
            Service? service = await _servicesRepository.GetById(id);

            if (service == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ServiceReadDto>(service));
        }

        [HttpPost(template: "create")]
        public async Task<IActionResult> CreateService(ServiceCreateDto serviceCreateDto)
        {
            Service newService = _mapper.Map<Service>(serviceCreateDto);

            try
            {
                await _servicesRepository.CreateService(newService);
                await _servicesRepository.Commit();

                ServiceReadDto result = _mapper.Map<ServiceReadDto>(newService);

                return CreatedAtRoute(
                    nameof(GetService),
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
