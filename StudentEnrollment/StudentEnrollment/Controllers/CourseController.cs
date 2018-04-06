using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Controllers
{
    public class CourseController : Controller
    {
        private readonly Data.CourseContext _context;

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

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(course))
            {
                courses = courses.Where(c => c.Name == course);
            }

            var courseNamesVM = new CourseViewModel();
            courseNamesVM.name = new SelectList(await courseQuery.Distinct().ToListAsync());
            courseNamesVM.courses = await courses.ToListAsync();
            

            return View(courseNamesVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.SingleOrDefaultAsync(c => c.ID == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Course course)
        {

        }
    }
}
