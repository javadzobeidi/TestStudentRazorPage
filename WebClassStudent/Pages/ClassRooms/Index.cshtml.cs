using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataClassStudent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebClassStudent.Pages.ClassRooms
{
    public class IndexModel : PageModel
    {
        public readonly ClassStudentDbContext _context;
        
        public List<ClassRoom> rooms { set; get; }
        public IndexModel(ClassStudentDbContext context)
        {
            this._context = context;
        }
        public void OnGet()
        {
         rooms = _context.ClassRooms.ToList();

        }

      
        public async Task< JsonResult> OnGetDeleteClassRoom(int id)
        {
            try
            {
                var classRoom = _context.ClassRooms.Where(d => d.Id == id).FirstOrDefault();
                if (classRoom == null)
                {
                    return new JsonResult("class number is wrong");
                }
                _context.ClassRooms.Remove(classRoom);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException )
            {
                return new JsonResult("you can't delete class there are some student in the class");

            }

            return new JsonResult("OK");
        }

    }
}
