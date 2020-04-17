//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student001.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate(); // i version 3.1.1 og 3.1.3 er måske forskellige
        }
        public DbSet<Student> Student { get; set; }
    }

    // DbSet<Student> Student er linket til tabellen student, men det ligger jo i klassen DatabaseContext
}
