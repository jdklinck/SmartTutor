using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Models.TutorModels
{
    public class TutorEdit
    {
        public int TutorId { get; set; }

        [Display(Name = "Tutor Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Session Rate")]
        public decimal Rate { get; set; }
    }
}
