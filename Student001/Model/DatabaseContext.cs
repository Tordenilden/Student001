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
        public DbSet<TeacherCourse> TeacherCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // dette er 1-M M-1   her er samlingstabellen
            modelBuilder.Entity<TeacherCourse>()
            .HasKey(t => new { t.teacherId, t.courseId });


        }
    }
    //modelBuilder.Entity<TeacherCourse>()
    //    .HasOne(pt => pt.Movie)
    //    .WithMany(p => p.MovieGenres)
    //    .HasForeignKey(pt => pt.movieId);

    //modelBuilder.Entity<TeacherCourse>()
    //    .HasOne(pt => pt.Genre)
    //    .WithMany(t => t.MovieGenres)
    //    .HasForeignKey(pt => pt.genreId);


    //override på modelbuilder (protected) -- så ikke hashset
    // DbSet<Student> Student er linket til tabellen student, men det ligger jo i klassen DatabaseContext
}
