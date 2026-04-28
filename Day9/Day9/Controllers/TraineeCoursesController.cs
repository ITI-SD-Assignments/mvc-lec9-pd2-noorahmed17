using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Day8.Models;

namespace Day8.Controllers
{
    [Route("Enrollment")]
    public class TraineeCoursesController : Controller
    {
        private readonly ITraineeCourse _tcRepo;
        private readonly ITrainee _traineeRepo;
        private readonly ICourse _courseRepo;

        public TraineeCoursesController(ITraineeCourse tcRepo, ITrainee traineeRepo, ICourse courseRepo)
        {
            _tcRepo = tcRepo;
            _traineeRepo = traineeRepo;
            _courseRepo = courseRepo;
        }
        [Route("All")]
        public IActionResult Index() { return View(_tcRepo.GetAll()); }
        [Route("Add")]
        public IActionResult Create()
        {
            ViewBag.TraineeID = _traineeRepo.GetAll()
                .Select(t => new SelectListItem { Value = t.ID.ToString(), Text = t.Name });

            ViewBag.CourseID = _courseRepo.GetAll()
                .Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Topic });

            return View();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Create(TraineeCourse tc)
        {
            _tcRepo.Add(tc);
            return RedirectToAction(nameof(Index));
        }
        [Route("Details/{traineeId:int}/{courseId:int}")]
        public IActionResult Details(int traineeId, int courseId)
        {
            var tc = _tcRepo.GetById(traineeId, courseId);
            if (tc == null) return NotFound();
            return View(tc);
        }
        public IActionResult Edit(int traineeId, int courseId)
        {
            var tc = _tcRepo.GetById(traineeId, courseId);
            if (tc == null) return NotFound();
            return View(tc);
        }

        [HttpPost]
        public IActionResult Edit(TraineeCourse tc)
        {
            _tcRepo.Update(tc);
            return RedirectToAction(nameof(Index));
        }
 
        [HttpGet]
        public IActionResult Delete(int traineeId, int courseId)
        {
            var tc = _tcRepo.GetById(traineeId, courseId);
            if (tc == null) return NotFound();

            return View(tc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int TraineeID, int CourseID)
        {
            _tcRepo.Delete(TraineeID, CourseID);
            return RedirectToAction(nameof(Index));
        }
    }
}