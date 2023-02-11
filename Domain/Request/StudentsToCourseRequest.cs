using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class StudentsToCourseRequest
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
