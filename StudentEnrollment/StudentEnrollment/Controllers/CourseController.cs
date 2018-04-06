using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseContext _context;

        public CourseController(CourseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string course, string searchString)
        {
            IQueryable<string> courseQuery = from c in _context.Course
                                             orderby c.Name
                                             select c.Name;

            var courses = from c in _context.Course
                          select c;

            var courseStudent = new CourseStudentsViewModel();
            courseStudent.
        }
    }
}
