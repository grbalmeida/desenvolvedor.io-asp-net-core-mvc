using DevIO.ModelApp.Data;
using DevIO.ModelApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DevIO.ModelApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MyDbContext _context;

        public StudentsController(MyDbContext context)
        {
            _context = context;
        }
        
        [Route("students-crud")]
        public IActionResult Index()
        {
            var student = new Student
            {
                Name = "Eduardo",
                DateOfBirth = DateTime.Now,
                Email = "eduardo@eduardopires.net.br"
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            var student2 = _context.Students.Find(student.Id);
            var student3 = _context.Students.FirstOrDefault(s => s.Email == "eduardo@eduardopires.net.br");
            var student4 = _context.Students.Where(s => s.Name == "Eduardo").ToList();

            student.Name = "John";

            _context.Students.Update(student);
            _context.SaveChanges();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return View();
        }
    }
}
