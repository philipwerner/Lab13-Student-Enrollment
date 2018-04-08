using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class CourseViewModel
    {
        public List<Course> courses;
        public List<Student> students;
        public SelectList name;
        public string CourseName { get; set; }
    }
}
