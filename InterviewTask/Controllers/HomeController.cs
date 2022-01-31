using InterviewTask.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Prepare your opening times here using the provided HelperServiceRepository class.       
         */
        public ActionResult Index()
        {
            var helperServiceRepository = new HelperServiceRepository();
            try
            {              
                var model = helperServiceRepository.Get();
                return View(model);
            }
            catch (Exception ex)
            {
                // log to exceptions
                helperServiceRepository.WriteLog(ex.Message.ToString());
            }
           // return RedirectToAction("Error", "Shared");
            return Redirect("~/Error.html"); 
        }


      

        [HttpPost]
        public ActionResult WriteLog(string Log)
        {
            try
            {
                var helperServiceRepository = new HelperServiceRepository();
                helperServiceRepository.WriteLog(Log);
            }
            catch
            {
                return Redirect("~/Error.html");
            }
            return null;
        }       

    }
}