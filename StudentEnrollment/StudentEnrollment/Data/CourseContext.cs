﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext (DbContextOptions<CourseContext> options) : base(options)
        {

        }

        public DbSet<StudentEnrollment.Models.Course> Course { get; set; }
    }
}
