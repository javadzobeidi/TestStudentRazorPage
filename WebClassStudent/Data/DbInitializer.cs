#define Final // Final // or Final // or Intro

using System;
using System.Collections.Generic;
using System.Linq;
using DataClassStudent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebClassStudent
{
    public static class DbInitializer
    {
        public static void Initialize(ClassStudentDbContext context)
        {
            //context.Database.EnsureCreated();


            if (context.ClassRooms.Any())
            {
                return;
            }

            var rooms = new ClassRoom[]
            {
                new ClassRoom
                {
                    ClassName="Biology",
                   Location="Building 5 Room",
                   TeacherName="Mr Robertson",
                   Students=new List<Student>()
                   {
                       new Student
                       {
                           StudentName="David Jackson",
                           Age=19,
                           Gpa=3.4
                           
                       },
                           new Student
                       {
                           StudentName="Peter Parker",
                           Age=19,
                           Gpa=3.2

                       },
                               new Student
                       {
                           StudentName="Robert Smit",
                           Age=19,
                           Gpa=1.2

                       },
                   }
                }
            };
            context.ClassRooms.AddRange(rooms);
            context.SaveChanges();


        }
    }
}
