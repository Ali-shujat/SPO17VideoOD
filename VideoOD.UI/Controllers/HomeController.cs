using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoOD.Data.Data.Entities;
using VideoOD.Data.Repositories;
using VideoOD.UI.Models;

namespace VideoOD.UI.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<User> _signInManager;
        public HomeController(SignInManager<User> signInMgr)
        {
            _signInManager = signInMgr;
        }
        public IActionResult Index()
        {
            //var rep = new MockReadRepository();
            //var courses = rep.GetCourses("5362a583-5d36-4076-aecc-2637e17fbeae");
            //var course = rep.GetCourse("5362a583-5d36-4076-aecc-2637e17fbeae", 1);
            //var videos = rep.GetVideos("5362a583-5d36-4076-aecc-2637e17fbeae");
            //var videoformodule = rep.GetVideo("5362a583-5d36-4076-aecc-2637e17fbeae", 1);

            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Login", "Account");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
