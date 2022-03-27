using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESTUDENT.Data;
using Microsoft.Extensions.Configuration;

namespace ESTUDENT.Repositories
{

    public interface IStudentExamRepository : IBaseRepository<StudentExam>{

    }

    public class StudentExamRepository : BaseRepository<StudentExam>, IStudentExamRepository
    {
        public StudentExamRepository(IConfiguration configuration) : base(configuration)
        {
        }

       
    }
}
