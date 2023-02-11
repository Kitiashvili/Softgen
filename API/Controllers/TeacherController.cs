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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;
        public readonly IMapper _mapper;

        public TeacherController(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllTeacher")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher([FromQuery] TeacherDTO teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            await _repository.AddAsync(teacher);

            return Ok(teacher);
        }
        [HttpPut("UpdateTeacher {id}")]
        public async Task<IActionResult> UpdateTeacher(Guid id, [FromQuery] TeacherDTO teacherDto)
        {
            var _teacher = await _repository.GetByIdAsync(id);
            if (_teacher != null)
            {
                var teacher = _mapper.Map<TeacherDTO, Teacher>(teacherDto, _teacher);
                await _repository.Update(_teacher);
            }

            return Ok(_teacher);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] SearchPersonRequest request)
        {
            var teacher = _repository.Query()
               .Where((s => s.FirstName.Contains(request.FirstName) ||
               s.LastName.Contains(request.LastName) ||
               s.PersonalNumber.Contains(request.PersonalNumber) ||
               s.DateOfBirth.Equals(request.DateOfBirth)));

            if (teacher is null)
                return NotFound();

            return Ok(teacher);
        }
    }
}
