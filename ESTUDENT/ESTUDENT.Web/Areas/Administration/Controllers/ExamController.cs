using ESTUDENT.Models;
using ESTUDENT.Services;
using ESTUDENT.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ESTUDENT.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[controller]/[action]/{id?}")]
    public class ExamController : BaseController
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
        public ExamController(IService service)
        {
                this.service = service;
        }
        #endregion


        #region Actions/Functions
        /// <summary>
        /// Get All Exams
        /// </summary>
        /// <returns></returns>
        public IActionResult Exams()
        {

            // List<ExamModel> result = service.ReadAllExams();
            //List<StudentStudentExamExamModel> result2 = service.ReadAllCancelledExamsByStudentId(1);
            //return View(result);

            return View();
        }


        /// <summary>
        /// Get All Rows
        /// </summary>
        /// <returns></returns>
        public IActionResult Rows(int pageNumber, int rowsPerPage, string search)
        {
            List<ExamModel> result = service.TableSearch(pageNumber, rowsPerPage, search);

            return View(result);
        }


        /// <summary>
        /// Get All Exams
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {

            return View();
        }


        /// <summary>
        /// Get All active Exams from StudentExam table 
        /// </summary>
        /// <returns></returns>
        public IActionResult ActiveExams() {

            List<StudentStudentExamExamModel> result = service.ReadAllActiveExams();
            return View(result);
        }


        /// <summary>
        /// Get All registered Exams from StudentExam table 
        /// </summary>
        /// <returns></returns>

        public IActionResult RegisteredExams()
        {

            List<StudentStudentExamExamModel> result = service.ReadAllRegisteredExams();
            return View(result);
        }

        #endregion
    }
}
