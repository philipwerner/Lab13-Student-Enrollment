using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        public DbSet<StudentEnrollment.Models.Course> Course { get; set; }
        public DbSet<StudentEnrollment.Models.Student> Student { get; set; }
    }
}
