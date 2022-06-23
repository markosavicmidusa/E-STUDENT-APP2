using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESTUDENT.Data;
using ESTUDENT.Models;

namespace ESTUDENT.Services
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            
            CreateMap<StudentStudentExamExam, StudentStudentExamExamModel>().ReverseMap();
            /*    .ForMember( dest=> dest.Professor, opt => opt.MapFrom(src =>(src.Professor))  )*/
                ;
            CreateMap<Exam, ExamModel>().ReverseMap();
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<StudentExam, StudentExamModel>().ReverseMap();
        }

    }
}
