using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Models.StudentModels
{
    public class StudentListItem
    {
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        public string FullName { get; set; }
    }
}
