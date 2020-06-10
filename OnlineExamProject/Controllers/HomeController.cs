using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineExamProject.Models;

namespace OnlineExamProject.Controllers
{
    public class HomeController : Controller
    {
        TblStudent student = new TblStudent();
        List<Questions> questions = new List<Questions>();
        DBEXAMContext dBEXAMContext = new DBEXAMContext();
        
        private readonly ILogger<HomeController> _logger;

     

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
      

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
             return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult tLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult tLogin(TblAdmin tbladmin)
        {
            TblAdmin admin = dBEXAMContext.TblAdmin.Where(i => i.AdName == tbladmin.AdName && i.AdPassword == tbladmin.AdPassword).SingleOrDefault();
            if (admin!=null)
            {
               return RedirectToAction("DashBoard");
            }
            else
            {
                ViewBag.msg = "Imvalid username or password";
            }
            return View();
        }
        public IActionResult slogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult slogin(TblStudent stu)
        {
            
           
            TblStudent t = new TblStudent();
          
            t.SName = stu.SName;
            t.SPassword = stu.SPassword;
            dBEXAMContext.TblStudent.Add(t);
            dBEXAMContext.SaveChanges();
            return RedirectToAction("QuizStart");

          
        }

        public IActionResult QuizStart(int id)
        {
            
            var newmodel = dBEXAMContext.Questions.FirstOrDefault(i => i.QuestionId == id);

            return View(newmodel);

            

        }
        [HttpPost]
        public IActionResult QuizStart( )
        {

            return View();
        }

        public IActionResult DashBoard()
        {
            return View();
        }

        public IActionResult AddQuestion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddQuestion(Questions q)
        {
            
           
            dBEXAMContext.Questions.Add(q);
            dBEXAMContext.SaveChanges();
            ViewBag.msg = "add questions succesfull";

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
