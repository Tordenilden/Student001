﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student001.Model
{
    public class Teacher // Show
    {

        public int teacherId { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public IList<TeacherCourse> TeacherCourse { get; set; }
    }
}
