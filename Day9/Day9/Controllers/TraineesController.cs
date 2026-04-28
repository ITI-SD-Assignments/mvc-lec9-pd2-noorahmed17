using Day8.Models;
using Day8.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day8.Controllers
{
    [Route("Trainee")]
    public class TraineesController : Controller
    {
        private readonly ITrainee _traineeRepo;
        private readonly ITrack _trackRepo;

        public TraineesController(ITrainee traineeRepo, ITrack trackRepo)
        {
            _traineeRepo = traineeRepo;
            _trackRepo = trackRepo;
        }
        [Route("All")]
        public IActionResult Index()
        {
            return View(_traineeRepo.GetAll());
        }
        // GET: Trainees/Create
        [Route("New")]
        public IActionResult Create()
        {
            ViewBag.TrackID = _trackRepo.GetAll()
                .Select(t => new SelectListItem { Value = t.ID.ToString(), Text = t.Name });

            ViewBag.Genders = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(g => new SelectListItem
                {
                    Text = g.ToString(),
                    Value = ((int)g).ToString()
                });

            return View();
        }

        [HttpPost]
        [Route("New")]
        public IActionResult Create(Trainee trainee)
        {
            if (trainee != null)
            {
                _traineeRepo.Add(trainee); 
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TrackID = _trackRepo.GetAll()
                .Select(t => new SelectListItem { Value = t.ID.ToString(), Text = t.Name });

            ViewBag.Genders = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(g => new SelectListItem
                {
                    Text = g.ToString(),
                    Value = ((int)g).ToString()
                });

            return View(trainee);
        }
        [Route("Edit/{id:int:min(1)}")]
        public IActionResult Edit(int id)
        {
            var trainee = _traineeRepo.GetById(id);
            if (trainee == null) return NotFound();
            ViewBag.TrackID = _trackRepo.GetAll()
                .Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.Name,
                    Selected = (t.ID == trainee.TrackID)
                });
            ViewBag.Genders = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(g => new SelectListItem
                {
                    Text = g.ToString(),
                    Value = ((int)g).ToString(),
                    Selected = (g == trainee.Gender)
                });
            //ViewBag.Tracks = _trackRepo.GetAll();
            return View(_traineeRepo.GetById(id));
        }

        [HttpPost]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(Trainee trainee)
        {
            _traineeRepo.Update(trainee);
            return RedirectToAction(nameof(Index));
        }
        [Route("Remove/{id:int}")]
        public IActionResult Delete(int id)
        {
            _traineeRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
