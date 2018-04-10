using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class StudentViewModel
    {
        public List<Student> students;
        public SelectList firstName;
        public string StudentName { get; set; }
    }
}
