using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<StudentEnrollment.Models.Student> Student { get; set; }
    }
}
