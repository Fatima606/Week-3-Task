using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using W3_D2_01.Models;

namespace W3_D2_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentContext _studentContext;

        public HomeController(ILogger<HomeController> logger, StudentContext studentContext)
        {
            _logger = logger;
            _studentContext = studentContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Student st)
        {
            _studentContext.Add(st);
            _studentContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetStudents()
        {
            //Lazy Loading

            List<Student> st=_studentContext.Students.ToList();
            var totalStudents = st.Count();
            //IEnumerable<Student> st=_studentContext.Students;


            //Explicit Loading

            //Student student = _studentContext.Students.FirstOrDefault(a => a.Id == 1);
            //_studentContext.Entry(student).Reference(u => u.Name).Load();


            //Eager Loading
            //List<Student> student_Eager = _studentContext.Students.Include(u=>u.Gender).ToList();

            return View(st);
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