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
    public interface IExamRepository : IBaseRepository<Exam>{

        public List<Exam> ReadAllExamsByYear(int student_id);


    }


    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        private readonly IStudentRepository studentRepository;

        public ExamRepository(IConfiguration configuration, IStudentRepository studentRepository) : base(configuration) {

            this.studentRepository= studentRepository;
            

        }

      



        /// <summary>
        /// Returns a List of Exams by Students current Year , and using string Year as a parametar
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Exam> ReadAllExamsByYear(int student_id)
        {
            Student student = studentRepository.ReadOne(student_id);
            var student_year = student.Year;
            List<Exam>? results = connection.Query<Exam>($"SELECT * FROM estudent.exams WHERE `year` = {student_year}").ToList();
            return results;

        }
    }


}
