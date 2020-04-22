using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student001.Model
{
    public class TeacherCourse
    {
        //public int teacherCourseId { get; set; }
        public int teacherId { get; set; } // denne skal afspejle PK i Teacher
        public Teacher teacher { get; set; } // fortæller at vi benytter PK fra Teacher
        public int courseId { get; set; }
        public Course course { get; set; }
    }
}
