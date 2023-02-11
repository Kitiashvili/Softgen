using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public int CourseN { get; set; }

        public Course(string name, int courseN)
        {
            Name = name;
            CourseN = courseN;
            Students  = new List<Students>();
        }
        public ICollection<Students>? Students{ get; set; }
        public Guid? TeacherID { get; set; }
        [ForeignKey("TeacherID")]
        public virtual Teacher? Teacher { get; set; }
    }
}
