using Microsoft.AspNetCore.Mvc;
using ESTUDENT.Models;
using ESTUDENT.Services;
using ESTUDENT.Web.Controllers;

namespace ESTUDENT.Web.Areas.Administration.Controllers
{

    [Area("Administration")]
    [Route("Administration/[controller]/[action]/{id?}")]
    public class StudentController : BaseController
    {
        

        #region Dependency injection
        /// <summary>
        /// Get Main Service
        /// </summary>
        private IService service;
        #endregion


        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service"></param>
        public StudentController(IService service)
        {
            this.service = service;
        }
        #endregion


        #region Actions/Functions

        public IActionResult Students()
        {
           // List<StudentModel> result = service.ReadAllStudents();
           // return View(result);
            return View();
        }

        public IActionResult Rows(int pageNumber, int rowsPerPage, string search)
        {
            List<StudentModel> result = service.TableSearchStudents(pageNumber, rowsPerPage, search);
            return View(result);
        }

        /// <summary>
        /// Load student method
        /// </summary>
        /// <returns></returns>
        public IActionResult Create() {

            return View();
        }


        /// <summary>
        /// Create student method
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(StudentModel model)
        {

            if (!ModelState.IsValid) {

                TempData["Response"] = false;
                TempData["ResponseMessage"] = "Neuspesno kreiran Student";
                return View(model);
            }
            try
            {
               var result =  service.CreateStudent(model);
                if (result != null)
                {
                    TempData["Response"] = true;
                    TempData["ResponseMessage"] = "Uspesno kreiran Student";
                }
                else{
                    TempData["Response"] = false;
                    TempData["ResponseMessage"] = "Neuspesno kreiran Student";
                }
               return View(model);
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return View(model);
            }

            return View();
        }

        /// <summary>
        /// Retrive the data from specific student by its id
        /// </summary>
        /// <returns></returns>
        public IActionResult Update(int id)
        {
            StudentModel model = service.ReadOneStudent(id);
            return View(model);
        }


        /// <summary>
        /// Create student method
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(StudentModel model)
        {

            if (!ModelState.IsValid)
            {

                TempData["Response"] = false;
                TempData["ResponseMessage"] = "Neuspesno update-ovan Student";
                return View(model);
            }
            try
            {
                service.UpdateStudent(model);
                TempData["Response"] = true;
                TempData["ResponseMessage"] = "Uspesno update-ovan Student";
                return View(model);

            }
            catch (Exception ex)
            {
                TempData["Response"] = false;
                TempData["ResponseMessage"] = "Neuspesno update-ovan Student";
                Console.WriteLine(ex.Message);
                return View(model);
            }

         
        }

        #endregion
    }
}
