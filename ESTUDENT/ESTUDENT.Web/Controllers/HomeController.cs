using System.Diagnostics;
using ESTUDENT.Data;
using ESTUDENT.Repositories;
using ESTUDENT.Services;
using ESTUDENT.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESTUDENT.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService service;
        //private readonly IExamRepository examRepository;
        //private readonly IStudentRepository studentRepository;
        //private readonly IStudentExamRepository studentExamRepository;
        

        public HomeController(ILogger<HomeController> logger, IService service/*, IExamRepository examRepository, IStudentRepository studentRepository, IStudentExamRepository studentExamRepository*/)
        {
            _logger = logger;
            this.service = service;
            //this.examRepository = examRepository;
            //this.studentRepository = studentRepository;
            //this.studentExamRepository = studentExamRepository;
        
        }

        public IActionResult Index()
        {

            //List<Exam> results = examRepository.ReadAll();
            //List<Exam> resultsFromYear = examRepository.ReadAllExamsByYear(1);
            //List<Student> students = studentRepository.ReadAll();
            //List<StudentExam> studentExam = studentExamRepository.ReadAll();
            //StudentExam studentReadOne = studentExamRepository.ReadOne(1);
            //List<StudentStudentExamExam> studentExamReadAllExamsByStudentId = studentExamRepository.ReadAllExamsByStudentId(1);
            //List<StudentStudentExamExam> studentExamReadAllActiveExamsByStudentId = studentExamRepository.ReadAllActiveExamsByStudentId(1);
            //List<StudentStudentExamExam> studentExamReadAllCancelledExamsByStudentId = studentExamRepository.ReadAllCancelledExamsByStudentId(1);
            //List<StudentStudentExamExam> studentExamReadAllFinishedExamsByStudentId = studentExamRepository.ReadAllFinishedExamsByStudentId(1);

            /*StudentExam sx =  new StudentExam();
            sx.Status = "active";
            sx.ExamId = 19;
            sx.StudentId = 1;

            int createResult = studentExamRepository.Create(sx);
            Console.WriteLine(createResult);
           */


            var result = service.ReadAllExamsByYear(1);
            var result1 = service.ReadAllExamsByStudentId(1);


            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}