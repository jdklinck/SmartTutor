using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Models.StudentModels
{
    public class StudentEdit
    {
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Students Grade")]
        public int Grade { get; set; }
    }
}
