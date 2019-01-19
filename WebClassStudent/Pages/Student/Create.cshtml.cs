using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataClassStudent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebClassStudent.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataClassStudent.ViewModel;
namespace WebClassStudent.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly ClassStudentDbContext _context;
        private readonly IMapper _mapper;

        [BindProperty]
        public StudentItemViewModel student { set; get; }

        public CreateModel(ClassStudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }



        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id.HasValue == false)
                return NotFound();

         var classRoom=  await _context.ClassRooms.Where(d => d.Id == id).FirstOrDefaultAsync();
            if (classRoom == null)
                return NotFound();



            student = new StudentItemViewModel
            {
                classRoomId = id.Value
            };

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DataClassStudent.Student studentItem = null;

           if (_context.Students.Where(d=>d.ClassRoomId==student.classRoomId && d.StudentName.CompareTo(student.studentName)==0).Count()>0)
            {
                ModelState.AddModelError(string.Empty, "Your Student Name is duplicated ");
                return Page();
            }


            if (student.id.HasValue == true)
            {
                studentItem = await _context.Students.Where(d => d.Id ==student.id).FirstOrDefaultAsync();
              studentItem=  _mapper.Map<DataClassStudent.Student>(student);
               
            }
            else
            {
                studentItem = _mapper.Map<DataClassStudent.Student>(student);
                 _context.Students.Add(studentItem);

            }



            await _context.SaveChangesAsync();
            return RedirectToPage("./Index",new {id= student.classRoomId });


        }

     
    }
}