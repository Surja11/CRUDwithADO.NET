using CRUDADO.DAL;
using CRUDADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDADO.Controllers
{
    public class StudentController : Controller
    {
        private readonly Student_DAL _dal;

        public StudentController(Student_DAL dal)
        {
            _dal = dal;
        }
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            students = _dal.GetAllStudents();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {
            bool result = _dal.Insert(model);
            return RedirectToAction("Index");
        }

        [HttpGet("Student/Edit/{Roll}")]
        public IActionResult Edit([FromRoute] int Roll)
        {
            Student student = new Student();
            student = _dal.GetByRoll(Roll);
            return View(student);

        }


        [HttpPost]
        public IActionResult Edit(Student stu)
        {
            _dal.Update(stu);

            return RedirectToAction("Index");
        }

        [HttpGet("Student/Delete/{Roll}")]
        public IActionResult Delete([FromRoute] int Roll)
        {
            Student stu = new Student(); 
            stu = _dal.GetByRoll(Roll);
            if (stu == null)
            {
                return NotFound();
            }    
            return View(stu);      
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Roll)
        {
           
                bool result = _dal.Delete(Roll);
                return RedirectToAction("Index"); 

           
        }

    }
}
