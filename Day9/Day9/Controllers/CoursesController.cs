using Day8.Models;
using Day8.RepoServices; // Ensure this namespace is correct for ICourse
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day8.Controllers
{
    [Route("Courses")] 
    public class CoursesController : Controller
    {
        private readonly ICourse _courseRepo;

        public CoursesController(ICourse courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [Route("All")]
        public IActionResult Index()
        {
            return View(_courseRepo.GetAll());
        }

        [Route("Details/{id:int:min(1)}")]
        public IActionResult Details(int id)
        {
            var course = _courseRepo.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [Route("Add")] 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Add(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [Route("Modify/{id:int}")]
        public IActionResult Edit(int id)
        {
            var course = _courseRepo.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [Route("Modify/{id:int}")]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Update(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
        [Route("Remove/{id:int}")]
        public IActionResult Delete(int id)
        {
            _courseRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}