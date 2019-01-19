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
    public class EditModel : PageModel
    {
        private readonly ClassStudentDbContext _context;
        private readonly IMapper _mapper;

        [BindProperty]
        public StudentItemViewModel student { set; get; }

        public EditModel(ClassStudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }



        public async Task<IActionResult> OnGetAsync(int? id)
        {

           
                student = await _context.Students.Where(d => d.Id == id).Select(d => new StudentItemViewModel
                {
                    id = d.Id,
                    studentName = d.StudentName,
                    age = d.Age,
                    gpa = d.Gpa,
                    classRoomId=d.ClassRoomId.Value
                }).FirstOrDefaultAsync();

                if (student == null)
                {
                    return NotFound();
                }
            
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DataClassStudent.Student studentItem = null;

           if (_context.Students.Where(d=>d.ClassRoomId==student.classRoomId && d.Id!=student.id && d.StudentName.CompareTo(student.studentName)==0).Count()>0)
            {
                ModelState.AddModelError(string.Empty, "Your Student Name is duplicated ");
                return Page();
            }


       
                studentItem = await _context.Students.Where(d => d.Id ==student.id).FirstOrDefaultAsync();

            _mapper.Map(student, studentItem);


            await _context.SaveChangesAsync();
            return RedirectToPage("./Index",new {id= student.classRoomId });


        }

     
    }
}