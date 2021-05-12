using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Students Grade")]
        public int Grade { get; set; }

        public virtual List<Subject> Subjects { get; set; }
    }
}
