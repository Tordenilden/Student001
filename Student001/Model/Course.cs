using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student001.Model
{
    public class Course
    {
      
        public int courseId { get; set; }
        public string coursename { get; set; }
        public virtual IList<TeacherCourse> TeacherCourse { get; set; } // så bliver det en ikke conrete navigation
    }
}
