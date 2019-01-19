using System;
using System.Collections.Generic;
using System.Text;

namespace DataClassStudent
{
  public  class Student
    {
        public int Id { set; get; }
        public int? ClassRoomId { set; get; }
        public String StudentName { set; get; }
        public int Age { set; get; }
        public double Gpa { set; get; }

        public virtual ClassRoom ClassRoom { set; get; }
    }
}
