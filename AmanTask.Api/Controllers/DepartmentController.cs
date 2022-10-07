

using AmanTask.Api.Dto;
using AmanTask.Core.Model;

namespace AmanTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<DepartmentDto>> GetAll()
        {
            var item=await _unitOfWork.Departments.GellAllAsync();

            var result = item.Select(e => new DepartmentDto()
            {
                Name=e.Name,
                Id = e.Id,

            }); 

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetById(int id)
        {
            if(id== null) return NotFound($"Not found Id ={id}");

            var item = await _unitOfWork.Departments.GetByIDAsync(id);
            if(item==null)
            {
                return NotFound($"Not found Id ={id}");
            }
            else
            {
                var result = new DepartmentDto()
                {
                    Name = item.Name,
                    Id=item.Id,
                };

                return Ok(result);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null) return NotFound($"Not found Id ={id}");

            var item = await _unitOfWork.Departments.GetByIDAsync(id);
            if (item == null)
            {
                return NotFound($"Not found Id ={id}");
            }
            else
            {
                await _unitOfWork.Departments.DeleteAsync(item);
                return NoContent();
            }

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<DepartmentDto>> updateDepartment(int id,DepartmentDto departmentDto)
        {
            if (id == null) return NotFound($"Not found Id ={id}");

            var item = await _unitOfWork.Departments.GetByIDAsync(id);
            if (item == null)
            {
                return NotFound($"Not found Id ={id}");
            }
            else
            {
                item.Name = departmentDto.Name;
                await _unitOfWork.Departments.UpdateAsync(item);

                var result = new DepartmentDto() {
                    Name=item.Name,
                    Id = item.Id,


                };
                return Ok(result);
            }

        }


        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> AddDeoartment( DepartmentDto department)
        {
           // if (!ModelState.IsValid) return BadRequest();

            var depart = new Department()
            {
                Id=department.Id,
                Name = department.Name,
            };
            
            var result=await _unitOfWork.Departments.AddAsync(depart);
            return Ok(department);
        }
    }
}
