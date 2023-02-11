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
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repository;
        public readonly IMapper _mapper;

        public CourseController(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllCourse")]
        public async Task<IActionResult> GetAllCourse()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse([FromQuery] CourseDTO courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _repository.AddAsync(course);

            return Ok(course);
        }
        [HttpPut("UpdateCourse {id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, [FromQuery] CourseDTO courseDto)
        {
            var _course = await _repository.GetByIdAsync(id);
            if (_course != null)
            {
                var course = _mapper.Map<CourseDTO, Course>(courseDto, _course);
                await _repository.Update(_course);
            }

            return Ok(_course);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] SearchCourseRequest request)
        {
            var course = _repository.Query()
               .Where(s => s.CourseN.Equals(request.CourseN));

            if (course is null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost("AddOrRemoveTeacher")]
        public async Task<IActionResult> AddOrRemoveTeacher(TeacherToCourseRequest request)
        {
            var course = await _repository.AddOrRemoveTeacher(request);
            return Ok(course);
        }

        [HttpPost("AddStudents")]
        public async Task<IActionResult> AddStudents(StudentsToCourseRequest request)
        {
            var course = await _repository.AddStudents(request);
            return Ok(course);
        }
        [HttpPost("RemoveStudents")]
        public async Task<IActionResult> RemoveStudents(StudentsToCourseRequest request)
        {
            var course = await _repository.RemoveStudents(request);
            return Ok(course);
        }
    }
}
