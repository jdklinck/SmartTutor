using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Data
{
    public class Tutor
    {
        [Key]
        public int TutorId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Tutor Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Session Rate")]
        public decimal Rate { get; set; }

        public virtual List<Subject> Subjects { get; set; }
    }
}
