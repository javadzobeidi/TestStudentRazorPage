using AutoMapper;
using DataClassStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataClassStudent.ViewModel;

namespace WebClassStudent.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ClassRoom, RoomItemViewModel>();
            CreateMap<RoomItemViewModel, ClassRoom>();


            CreateMap<Student, StudentItemViewModel>();
            CreateMap<StudentItemViewModel, Student>();

        }
    }
}
