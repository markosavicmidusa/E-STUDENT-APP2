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

    public interface IStudentExamRepository : IBaseRepository<StudentExam>{

        public List<StudentStudentExamExam> ReadAllExamsByStudentId(int id);

        public List<StudentStudentExamExam> ReadAllActiveExamsByStudentId(int id);
        public List<StudentStudentExamExam> ReadAllActiveExams();



        public List<StudentStudentExamExam> ReadAllRegisteredExams();





    }

    public class StudentExamRepository : BaseRepository<StudentExam>, IStudentExamRepository
    {
        



        public StudentExamRepository(IConfiguration configuration) : base(configuration)
        {

            

        }
       

       /* public List<StudentStudentExamExam> ReadAllFinishedExamsByStudentId(int id)
        {
            List<StudentStudentExamExam> results = connection.Query<StudentStudentExamExam>($"SELECT students_exams.id as `Id`  , students_exams.student_id as `StudentId` , students_exams.exam_id as `ExamId`, students_exams.`status` as `Status`, exams.`name` as `Name`, exams.professor as `Professor`, exams.assistant as `Assistant`, exams.`date` as `Date`, students.`name` as `StudentName`, students.surname as `Surname`, students.`index` as `Index`, students.`year` as `Year` FROM estudent.students_exams INNER JOIN exams ON exams.id = students_exams.exam_id INNER JOIN students ON students.id = students_exams.student_id WHERE students.`id` = {id} AND `Status` = 'finished'").ToList();
            return results;
        }*/

        /*public List<StudentStudentExamExam> ReadAllCancelledExamsByStudentId(int id)
        {
            List<StudentStudentExamExam> results = connection.Query<StudentStudentExamExam>($"SELECT students_exams.id as `Id`  , students_exams.student_id as `StudentId` , students_exams.exam_id as `ExamId`, students_exams.`status` as `Status`, exams.`name` as `Name`, exams.professor as `Professor`, exams.assistant as `Assistant`, exams.`date` as `Date`, students.`name` as `StudentName`, students.surname as `Surname`, students.`index` as `Index`, students.`year` as `Year` FROM estudent.students_exams INNER JOIN exams ON exams.id = students_exams.exam_id INNER JOIN students ON students.id = students_exams.student_id WHERE students.`id` = {id} AND `Status` = 'cancelled'").ToList();
            return results;
        }*/

        //var user = connection.GetList<User>("where age = 10 or Name like '%Smith%'");  

        public List<StudentStudentExamExam> ReadAllExamsByStudentId(int id)
        {
            List<StudentStudentExamExam> results = connection.Query<StudentStudentExamExam>($"SELECT students_exams.id as `Id`  , students_exams.student_id as `StudentId` , students_exams.exam_id as `ExamId`, students_exams.`status` as `Status`, exams.`name` as `Name`, exams.professor as `Professor`, exams.assistant as `Assistant`, exams.`date` as `Date`, students.`name` as `StudentName`, students.surname as `Surname`, students.`index` as `Index`, students.`year` as `Year` FROM estudent.students_exams INNER JOIN exams ON exams.id = students_exams.exam_id INNER JOIN students ON students.id = students_exams.student_id WHERE students.`id` = {id}").ToList();
            return results;

        }

        public List<StudentStudentExamExam> ReadAllActiveExamsByStudentId(int id)
        {
            List<StudentStudentExamExam> results = connection.Query<StudentStudentExamExam>($"SELECT students_exams.id as `Id`  , students_exams.student_id as `StudentId` , students_exams.exam_id as `ExamId`, students_exams.`status` as `Status`, exams.`name` as `Name`, exams.professor as `Professor`, exams.assistant as `Assistant`, exams.`date` as `Date`, students.`name` as `StudentName`, students.surname as `Surname`, students.`index` as `Index`, students.`year` as `Year` FROM estudent.students_exams INNER JOIN exams ON exams.id = students_exams.exam_id INNER JOIN students ON students.id = students_exams.student_id WHERE students.`id` = {id} AND `Status` = 'active'").ToList();
            return results;
        }

        public List<StudentStudentExamExam> ReadAllActiveExams()
        {
            List<StudentStudentExamExam> result = connection.Query<StudentStudentExamExam>("SELECT students_exams.id as `Id`  , students_exams.student_id as `StudentId` , students_exams.exam_id as `ExamId`, students_exams.`status` as `Status`, exams.`name` as `Name`, exams.professor as `Professor`, exams.assistant as `Assistant`, exams.`date` as `Date`, students.`name` as `StudentName`, students.surname as `Surname`, students.`index` as `Index`, students.`year` as `Year` FROM estudent.students_exams INNER JOIN exams ON exams.id = students_exams.exam_id INNER JOIN students ON students.id = students_exams.student_id WHERE `status`='active'").ToList();
            return result;
        }

        public List<StudentStudentExamExam> ReadAllRegisteredExams()
        {
            List<StudentStudentExamExam> result = connection.Query<StudentStudentExamExam>("SELECT students_exams.id as `Id`  , students_exams.student_id as `StudentId` , students_exams.exam_id as `ExamId`, students_exams.`status` as `Status`, exams.`name` as `Name`, exams.professor as `Professor`, exams.assistant as `Assistant`, exams.`date` as `Date`, students.`name` as `StudentName`, students.surname as `Surname`, students.`index` as `Index`, students.`year` as `Year` FROM estudent.students_exams INNER JOIN exams ON exams.id = students_exams.exam_id INNER JOIN students ON students.id = students_exams.student_id WHERE `status`='registered'").ToList();
            return result;
        }

      
    }
}
