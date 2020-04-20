using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student001.Model
{
    public class TeacherCourse
    {
        public int teacherCourseId { get; set; }
        public int teacherId { get; set; }
        public Teacher teacher { get; set; }
        public int courseId { get; set; }
        public Course course { get; set; }
    }
}
