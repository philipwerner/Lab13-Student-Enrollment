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
        private readonly Data.SchoolContext _context;

        public CourseController(SchoolContext context)
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

        public async Task<IActionResult> Enrolled(string course, string searchString)
        {
            IQueryable<string> enrolledQuery = from e in _context.Student
                                               orderby e.Course
                                               select e.Course;

            var enrolled = from e in _context.Student
                           select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                enrolled = enrolled.Where(e => e.Course.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(course))
            {
                enrolled = enrolled.Where(e => e.Course == course);
            }

            var studentsVM = new StudentViewModel();
            studentsVM.firstName = new SelectList(await enrolledQuery.Distinct().ToListAsync());
            studentsVM.students = await enrolled.ToListAsync();

            return View(studentsVM);
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
        public async Task<IActionResult> Create([Bind("Name,Level,Instructor")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Level,Instructor")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");

            }

            return View(course);
        }

        public async Task<IActionResult> Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var course = await _context.Course.SingleOrDefaultAsync(c => c.ID == id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(c => c.ID == id);
        }
    }
}
