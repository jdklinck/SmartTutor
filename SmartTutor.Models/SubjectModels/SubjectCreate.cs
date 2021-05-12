using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Models.SubjectModels
{
    public class SubjectCreate
    {
        

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Advanced")]
        public bool IsAdvanced { get; set; }

        public int TutorId { get; set; }

        public int StudentId { get; set; }
    }
}
