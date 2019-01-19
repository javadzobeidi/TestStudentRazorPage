using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClassStudent.ViewModel
{
    public class StudentIndexViewModel
    {
     public List<DataClassStudent.Student> students { set; get; }
        public string className { set; get; }
        public int id { set; get; }

    }
}
