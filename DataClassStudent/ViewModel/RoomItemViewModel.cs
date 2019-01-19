using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataClassStudent.ViewModel
{
    public class RoomItemViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Class Name")]
        public string className { set; get; }




        [Required]
        [StringLength(150)]
        [Display(Name = "Location")]
        public string location { set; get; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Teacher Name")]
        public string teacherName { set; get; }


        public int? id { set; get; }
    }
}
