using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyCircleManagementSystem.Entities;
using StudyCircleManagementSystem.BusinessLayer;

namespace StudyCircleManagementSystem.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(StudyCircleManagementSystem.Web.Models.LoginDetail detail)
        {

            LoginManager information = new LoginManager();
            StudyCircleManagementSystem.Web.Models.LoginDetail details = information.GetDetails(detail.UserName);

            if (details.UserName == detail.UserName && details.Password == detail.Password)
            {

                switch (details.Designation)
                {
                    case "Manager":
                        {
                            return View("Manager");
                        }
                    case "faculty":
                        {
                            return View("Faculty");
                        }
                    case "student":
                        {
                            return View("Student");
                        }
                }
            }
            return View();
        }


        public ActionResult Manager()
        {
            return View();
        }

        public ActionResult Faculty()
        {
            return View();
        }
        public ActionResult Student()
        {
            return View();
        }


    }
}
