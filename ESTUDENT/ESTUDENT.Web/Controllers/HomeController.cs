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
        private readonly IExamRepository productRepository;

        public HomeController(ILogger<HomeController> logger, IExamRepository productRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            List<Exam> results = productRepository.ReadAll();
           
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