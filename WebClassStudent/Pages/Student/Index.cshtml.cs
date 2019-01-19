using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataClassStudent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebClassStudent.ViewModel;

namespace WebClassStudent.Pages.Students
{
    public class IndexModel : PageModel
    {
        public readonly ClassStudentDbContext _context;
        
        public StudentIndexViewModel classRoom { set; get; }
        public IndexModel(ClassStudentDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  OnGetAsync(int? id)
        {
             classRoom = await _context.ClassRooms.Where(d => d.Id == id).Select(d=>new StudentIndexViewModel
             {
           className=      d.ClassName,
           id=d.Id,
           students=d.Students.ToList()
             }).AsNoTracking().FirstOrDefaultAsync();

            if (classRoom == null)
                return NotFound();



            return Page();


        }

        public async Task<JsonResult> OnGetDeleteStudent(int id)
        {
            var stu = _context.Students.Where(d => d.Id == id).FirstOrDefault();
            if (stu == null)
            {
                return new JsonResult("Student number is wrong");
            }
            _context.Students.Remove(stu);
            await _context.SaveChangesAsync();


            return new JsonResult("OK");
        }
       

    }
}
