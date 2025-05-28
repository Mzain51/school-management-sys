using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Students> students = _context.Students;
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Students student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
             
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Students student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(int student)
        {
               var std = _context.Students.Find(student);
                _context.Students.Remove(std);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }
}
