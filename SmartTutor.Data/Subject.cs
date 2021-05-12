using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Data
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Advanced")]
        public bool IsAdvanced { get; set; }

        [ForeignKey(nameof(Tutor))]
        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
