using SmartTutor.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Models.SubjectModels
{
    public class SubjectDetails
    {
        public int SubjectId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Advanced")]
        public bool IsAdvanced { get; set; }

        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
