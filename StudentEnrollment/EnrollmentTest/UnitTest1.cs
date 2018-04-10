using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Controllers;
using StudentEnrollment.Data;
using StudentEnrollment.Models;
using System;
using Xunit;

namespace EnrollmentTest
{
    public class UnitTest1
    {
        /*
        [Fact]
        public void Test1()
        {
            DbContextOptions<SchoolContext> options = new DbContextOptionsBuilder<SchoolContext>()
                .UseInMemoryDatabase("MyDbName")
                .Options;

            using (SchoolContext _context = new SchoolContext(options))
            {
                CourseController controller = new CourseController(_context);
                int tableCount = controller.GetType().Count();
                Assert.Equal(0, tableCount);

            }
        }
        */

        [Fact]
        public void CanCreateCourseWithoutInstructor()
        {
            Course testCourse = new Course() { ID = 1, Name = "testCourse", Level = 401 };

            Assert.NotNull(testCourse);
        }

        [Fact]
        public void CanAddInstructor()
        {
            Course testCourse = new Course() { ID = 1, Name = "testCourse", Level = 401 };

            testCourse.Instructor = "testInstructor";

            Assert.Equal("testInstructor", testCourse.Instructor);
        }

        [Fact]
        public void CanCreateCourseWithInstructo()
        {
            Course testCourse = new Course() { ID = 1, Name = "testCourse", Level = 401, Instructor = "instructor" };

            Assert.Equal("instructor", testCourse.Instructor);
        }

        [Fact]
        public void CanCreateStudent()
        {
            Student testStudent = new Student() { ID = 1, FirstName = "test", LastName = "student", Course = "test course" };

            Assert.NotNull(testStudent);
        }


    }
}
