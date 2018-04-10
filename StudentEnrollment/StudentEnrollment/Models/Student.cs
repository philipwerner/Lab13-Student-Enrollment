using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string LastName { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Course { get; set; }

    }
}
