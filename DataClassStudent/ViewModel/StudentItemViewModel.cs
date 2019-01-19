using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataClassStudent.ViewModel
{
    public class StudentItemViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Student Name")]
        public string studentName { set; get; }




        [Required]
       
        [Display(Name = "Age")]
        public double age { set; get; }


        [Required]
        [Display(Name = "GPA")]
        public double gpa { set; get; }

        public int classRoomId { set; get; }
        public int? id { set; get; }
    }
}
