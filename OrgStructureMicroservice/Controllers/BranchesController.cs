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
    public class BranchesController : ControllerBase
    {
        private readonly IBranchesRepository _branchesRepository;
        private readonly IMapper _mapper;

        public BranchesController(
            IBranchesRepository branchesRepository,
            IMapper mapper
        )
        {
            _branchesRepository = branchesRepository;
            _mapper = mapper;
        }

        [HttpGet(template: "getbycompany/{id}")]
        public async Task<IActionResult> GetCompanyBranches(int id)
        {
            List<Branch>? branches = 
                await _branchesRepository.GetBranchesByCompanyId(id);

            if (branches == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<BranchReadDto>>(branches));
        }

        [HttpGet(template: "get/{id}", Name = "GetBranch")]
        public async Task<IActionResult> GetBranch(int id)
        {
            Branch? branch = await _branchesRepository.GetBranch(id);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BranchReadDto>(branch));
        }

        [HttpPost(template: "create")]
        public async Task<IActionResult> CreateBranch(BranchCreateDto branchCreateDto)
        {
            Branch newBranch = _mapper.Map<Branch>(branchCreateDto);

            try
            {
                await _branchesRepository.CreateBranch(newBranch);
                await _branchesRepository.Commit();

                BranchReadDto result = _mapper.Map<BranchReadDto>(newBranch);

                return CreatedAtRoute(
                    nameof(GetBranch), 
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
