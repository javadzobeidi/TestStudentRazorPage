using System;
using System.Collections.Generic;
using System.Text;

namespace DataClassStudent
{
  public   class ClassRoom
    {
        public ClassRoom()
        {
            Students = new HashSet<Student>();
        }
        public int Id { set; get; }
        public string ClassName { set; get; }
        public string Location { set; get; }
        public string TeacherName { set; get; }

        public virtual ICollection<Student> Students { set; get; }

    }
}
