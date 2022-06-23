using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ESTUDENT.Data;
using ESTUDENT.Models;
using ESTUDENT.Repositories;

namespace ESTUDENT.Services
{

    public interface IService {

        #region Exams
        public List<ExamModel> ReadAllExamsByYear(int student_id);
        public List<ExamModel> ReadAllExams();
        public List<StudentStudentExamExamModel> ReadAllExamsByStudentId(int id);
        public List<StudentStudentExamExamModel> ReadAllActiveExamsByStudentId(int id);
        public List<StudentStudentExamExamModel> ReadAllActiveExams();
        public List<StudentStudentExamExamModel> ReadAllRegisteredExams();

        public List<ExamModel> TableSearch(int pageNumber, int rowsPerPage, string search);
        public List<StudentModel> TableSearchStudents(int pageNumber, int rowsPerPage, string search);

        #endregion

        #region Student

        public List<StudentModel> ReadAllStudents();
        public int CreateStudent(StudentModel obj);
        public StudentModel ReadOneStudent(int id);   
        public void UpdateStudent(StudentModel obj);


        #endregion




        public int CreateStudentExam(int student_id, int exam_id);
        public void UpdateStudentExamToActive(int student_id, int exam_id);
        public void UpdateStudentExamToFinished(int student_id, int exam_id);
        public void UpdateStudentExamToCancelled(int student_id, int exam_id);
        public void DeleteFromStudentExam(int student_id, int exam_id);
        

    }

    public class Service : IService
    {

        private  IExamRepository examRepository;
        private  IMapper mapperService;
        private  IStudentExamRepository studentExamRepository;
        private  IStudentRepository studentRepository;

        public Service(IExamRepository examRepository, IStudentRepository studentRepository, IStudentExamRepository studentExamRepository, IMapper mapperService)
        {
            this.examRepository=examRepository;
            this.studentRepository=studentRepository;
            this.studentExamRepository=studentExamRepository;
            this.mapperService=mapperService;
        }





        /// <summary>
        /// Responding with list of exams by year and id of certain user - Filtering function
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<ExamModel> ReadAllExamsByYear(int student_id)
        {

            List<Exam> exams = examRepository.ReadAllExamsByYear(student_id);
            List<ExamModel> result = mapperService.Map<List<ExamModel>>(exams);
            return result;
        }



            /// <summary>
            /// Responding with list of All exams
            /// </summary>
            /// <param name="year"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
        public List<ExamModel> ReadAllExams()
        {

            List<Exam> exams = examRepository.ReadAll();
            List<ExamModel> result = mapperService.Map<List<ExamModel>>(exams);
            return result;

        }



        /// <summary>
        /// Responding with list of exams from table StudentsExams
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<StudentStudentExamExamModel> ReadAllExamsByStudentId(int id)
        {
           
            List<StudentStudentExamExam> studentAllExams = studentExamRepository.ReadAllExamsByStudentId(id);
            List<StudentStudentExamExamModel> result = mapperService.Map<List<StudentStudentExamExamModel>>(studentAllExams); 

            return result;

        }

       


        /// <summary>
        /// Responding with list of All cancelled exams
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
       /* public List<StudentStudentExamExamModel> ReadAllCancelledExamsByStudentId(int id)
        {
            List<StudentStudentExamExam> studentCancelledExams = studentExamRepository.ReadAllCancelledExamsByStudentId(id);
            List<StudentStudentExamExamModel> result = mapperService.Map<List<StudentStudentExamExamModel>>(studentCancelledExams);
            return result;
        }*/

        /// <summary>
        /// Responding with list of All active exams of one student
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public List<StudentStudentExamExamModel> ReadAllActiveExamsByStudentId(int id)
        {
            List<StudentStudentExamExam> studentActiveExams = studentExamRepository.ReadAllActiveExamsByStudentId(id);
            List<StudentStudentExamExamModel> result = mapperService.Map<List<StudentStudentExamExamModel>>(studentActiveExams);
            return result;
        }


        /// <summary>
        /// Responding with list of All active exams in StudentsExams 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<StudentStudentExamExamModel> ReadAllActiveExams()
        {
            List<StudentStudentExamExam> studentsActiveExams = studentExamRepository.ReadAllActiveExams();
            List<StudentStudentExamExamModel> result = mapperService.Map<List<StudentStudentExamExamModel>>(studentsActiveExams);
            return result;
        }


        /// <summary>
        /// Responding with list of All registered exams in StudentsExams 
        /// </summary>
        public List<StudentStudentExamExamModel> ReadAllRegisteredExams()
        {
            List<StudentStudentExamExam> studentsRegisteredExams = studentExamRepository.ReadAllRegisteredExams();
            List<StudentStudentExamExamModel> result = mapperService.Map<List<StudentStudentExamExamModel>>(studentsRegisteredExams);
            return result;
        }


        /// <summary>
        /// Returns List of All Students
        /// </summary>
        public List<StudentModel> ReadAllStudents()
        {
            List<Student> studentsList = studentRepository.ReadAll();
            List<StudentModel> result = mapperService.Map<List<StudentModel>>(studentsList);
            return result;
        }

        /// <summary>
        ///  Table search
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<ExamModel> TableSearch(int pageNumber, int rowsPerPage, string search)
        {

            List<Exam> students = examRepository.TableSearch( pageNumber, rowsPerPage, $"WHERE Name LIKE '%{search}%' or Description LIKE '%{search}%'", "");
            List<ExamModel> result = mapperService.Map<List<ExamModel>>(students);
            return result;
        }


        /// <summary>
        /// Table search students
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<StudentModel> TableSearchStudents(int pageNumber, int rowsPerPage, string search)
        {
            List<Student> students = studentRepository.TableSearch(pageNumber, rowsPerPage, $"WHERE `Index` LIKE '%{search}%' or Surname LIKE '%{search}%'", "");
            List<StudentModel> result = mapperService.Map<List<StudentModel>>(students);
            return result;
        }


        /// <summary>
        /// Enter the StudentsExams Entity
        /// </summary>
        public int CreateStudentExam(int student_id, int exam_id)
        {
            StudentExam studentExam = new StudentExam();
            studentExam.StudentId = student_id;
            studentExam.ExamId = exam_id;
            studentExam.Status = "active";

            var result = studentExamRepository.Create(studentExam);
            return result;
        }



        /// <summary>
        /// Update the StudentsExams Entity status = active
        /// </summary>

        public void UpdateStudentExamToActive(int student_id, int exam_id)
        {

            StudentExam studentExam = new StudentExam();
            studentExam.StudentId = student_id;
            studentExam.ExamId = exam_id;
            studentExam.Status = "active";

            studentExamRepository.Update(studentExam);
          
        }


        /// <summary>
        /// Update the StudentsExams Entity status = finished
        /// </summary>
        public void UpdateStudentExamToFinished(int student_id, int exam_id)
        {
            StudentExam studentExam = new StudentExam();
            studentExam.StudentId = student_id;
            studentExam.ExamId = exam_id;
            studentExam.Status = "finished";

            studentExamRepository.Update(studentExam);
        }

        /// <summary>
        /// Update the StudentsExams Entity status = cancelled
        /// </summary>

        public void UpdateStudentExamToCancelled(int student_id, int exam_id)
        {
            StudentExam studentExam = new StudentExam();
            studentExam.StudentId = student_id;
            studentExam.ExamId = exam_id;
            studentExam.Status = "cancelled";

            studentExamRepository.Update(studentExam);
        }

        /// <summary>
        /// Delete the StudentsExams Entity status = unactive
        /// </summary>

        public void DeleteFromStudentExam(int student_id, int exam_id)
        {
            StudentExam studentExam = new StudentExam();
            studentExam.StudentId = student_id;
            studentExam.ExamId = exam_id;
            studentExam.Status = "unactive";
            studentExamRepository.Delete(studentExam);
        }

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CreateStudent(StudentModel obj)
        {
            return studentRepository.Create(mapperService.Map<Student>(obj));
        }

        public StudentModel ReadOneStudent(int id)
        {
            Student result = studentRepository.ReadOne(id);
            StudentModel student = mapperService.Map<StudentModel>(result);
            return student;
        }

        public void UpdateStudent(StudentModel obj)
        {
            studentRepository.Update(mapperService.Map<Student>(obj));
        }
    }
}
