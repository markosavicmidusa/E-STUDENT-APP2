using System.Diagnostics;
using ESTUDENT.Data;
using ESTUDENT.Repositories;
using ESTUDENT.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESTUDENT.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       /* private readonly IExamRepository examRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IStudentExamRepository studentExamRepository;*/

        public HomeController(ILogger<HomeController> logger, IExamRepository examRepository, IStudentRepository studentRepository, IStudentExamRepository studentExamRepository)
        {
            _logger = logger;
            /* this.examRepository = examRepository;
            this.studentRepository = studentRepository;
            this.studentExamRepository = studentExamRepository;
            */
        }

        public IActionResult Index()
        {
            /*
            List<Exam> results = examRepository.ReadAll();
            
            List<Student> students = studentRepository.ReadAll();

            List<StudentExam> studentExam = studentExamRepository.ReadAll();
            */

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