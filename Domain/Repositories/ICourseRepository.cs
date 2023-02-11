using Domain.Entities;
using Domain.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> AddOrRemoveTeacher(TeacherToCourseRequest request);

        Task<Course> AddStudents(StudentsToCourseRequest request);
        Task<Course> RemoveStudents(StudentsToCourseRequest request);


    }
}
