using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESTUDENT.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ESTUDENT.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student> { 
    
    }

    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IConfiguration configuration) : base(configuration)
        {

        }
      
    }
}
