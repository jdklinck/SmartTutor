using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Models.SubjectModels
{
    public class SubjectListItem
    {
        public int SubjectId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
