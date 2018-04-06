using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class CourseStudentsViewModel
    {
        public List<Course> courses;
        public SelectList course;
        public string CourseName { get; set; };
    }
}
