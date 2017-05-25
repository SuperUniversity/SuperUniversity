using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcClient.CoursesDbService;

namespace MvcClient.Controllers
{
    public class AsyncCoursesController : AsyncController
    {
        public void GetSuccessCoursesAsync()
        {
            AsyncManager.OutstandingOperations.Increment();
            Service1Client pxy = new Service1Client();
            pxy.GetSuccessCoursesCompleted += (sender, e) =>
            {
                AsyncManager.Parameters["Courses"] = e.Result;
                AsyncManager.OutstandingOperations.Decrement();
            };
            pxy.GetSuccessCourses();
        }


        // GET: AsyncCustomer
        public ActionResult GetSuccessCoursesCompleted(Service1Client[] Courses)
        {
            return View("GetSuccessCourses", Courses);  //ViewName, ModelSource
        }
    }
}
