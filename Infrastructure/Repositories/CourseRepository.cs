using Domain.Entities;
using Domain.Repositories;
using Domain.Request;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Course> , ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Course> AddOrRemoveTeacher(TeacherToCourseRequest request)
        {
            var teacher = await _context.Teachers.FindAsync(request.TeacherId);
            var course = await _context.Courses.FindAsync(request.CourseId);
            if (course is null || teacher is null)
                throw new Exception("Not Found");

            if (request.TeacherId == course.TeacherID)
            {
                course.Teacher = null;
                course.TeacherID = null;
            }
            else
                course.Teacher = teacher;

            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> AddStudents(StudentsToCourseRequest request)
        {
            var students = await _context.Students.FindAsync(request.StudentId);
            var course = await _context.Courses.FindAsync(request.CourseId);
            if (course is null || students is null)
                throw new Exception("Not Found");

            course.Students.Add(students);

            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }
        public async Task<Course> RemoveStudents(StudentsToCourseRequest request)
        {
            var student = await _context.Students.FindAsync(request.StudentId);
            var course = await _context.Courses.FindAsync(request.CourseId);
            if (course is null)
                throw new Exception("Not Found");

            course.Students.Remove(student);
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }


    }
}
