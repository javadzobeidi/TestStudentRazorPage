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
namespace WebClassStudent.Pages.ClassRooms
{
    public class CreateModel : PageModel
    {
        private readonly ClassStudentDbContext _context;
        private readonly IMapper _mapper;

        [BindProperty]
        public RoomItemViewModel room { set; get; }

        public CreateModel(ClassStudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id>0)
            {
               room=await _context.ClassRooms.Where(d => d.Id == id).Select(d => new RoomItemViewModel
                {
                    id = d.Id,
                    className = d.ClassName,
                    teacherName = d.TeacherName,
                    location = d.Location
                }).FirstOrDefaultAsync();
                if (room==null)
                {
                    return NotFound();
                }
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ClassRoom classRoom = null;

            if (room.id.HasValue == true)
            {
                classRoom = await _context.ClassRooms.Where(d => d.Id == room.id).FirstOrDefaultAsync();

                _mapper.Map(room,  classRoom);

          //    classRoom=  _mapper.Map<ClassRoom>(room);
            }
            else
            {
                classRoom = _mapper.Map<ClassRoom>(room);
                 _context.ClassRooms.Add(classRoom);

            }



            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }

     
    }
}