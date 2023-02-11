using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Repositories;
using Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _repository;
        public readonly IMapper _mapper;

        public StudentsController(IStudentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromQuery] StudentsDTO studentDto)
        {
            var student = _mapper.Map<Students>(studentDto);
            await _repository.AddAsync(student);

            return Ok(student);
        }
        [HttpPut("UpdateStudent {id}")]
        public async Task<IActionResult> UpdateStudent(Guid id,[FromQuery] StudentsDTO studentDto)
        {
            var _student = await _repository.GetByIdAsync(id);
            if(_student != null ) 
            {
                var student = _mapper.Map<StudentsDTO, Students>(studentDto, _student);
                await _repository.Update(_student);
            }
            
            return Ok(studentDto);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] SearchPersonRequest request)
        {
            var students = _repository.Query()
               .Where((s => s.FirstName.Contains(request.FirstName) ||
               s.LastName.Contains(request.LastName) ||
               s.PersonalNumber.Contains(request.PersonalNumber)||
               s.DateOfBirth.Equals(request.DateOfBirth)));

            if (students is null)
                return NotFound();

            return Ok(students);
        }
    }   
}
