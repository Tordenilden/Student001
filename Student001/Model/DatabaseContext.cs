//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student001.Model;

namespace Student001.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate(); // i version 3.1.1 og 3.1.3 er måske forskellige
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Zipcode> Zipcode { get; set; }
        public DbSet<Student001.Model.Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        //så er spørgsmålet fra mig til jer tror I der skal oprettes et DbSet<TeacherCourse> ??
    }

    // DbSet<Student> Student er linket til tabellen student, men det ligger jo i klassen DatabaseContext
}
