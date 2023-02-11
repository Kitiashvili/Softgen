using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class TeacherToCourseRequest
    {
        public Guid TeacherId { get; set; }
        public Guid CourseId { get; set; }

    }
}
