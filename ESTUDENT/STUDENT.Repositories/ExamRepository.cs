using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ESTUDENT.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ESTUDENT.Repositories
{
    public interface IExamRepository<Exam> : IBaseRepository<Exam> //where TEntity : class
    {

    }
    public class ExamRepository : BaseRepository<Exam>, IExamRepository<Exam>
    {
        public ExamRepository(IConfiguration configuration) : base(configuration)
        {
        }


    }
}
