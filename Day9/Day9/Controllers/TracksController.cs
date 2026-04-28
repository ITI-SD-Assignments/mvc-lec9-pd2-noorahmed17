using Day8.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day8.Models; // Ensure your Track model namespace is included

namespace Day8.Controllers
{
    [Route("Track")] 
    public class TracksController : Controller
    {
        private readonly ITrack _trackRepo;

        public TracksController(ITrack trackRepo)
        {
            _trackRepo = trackRepo;
        }

        [Route("All")] 
        public IActionResult Index()
        {
            return View(_trackRepo.GetAll());
        }

        [Route("Details/{id:int:min(1)}")]
        public IActionResult Details(int id)
        {
            var track = _trackRepo.GetById(id);
            if (track == null) return NotFound();
            return View(track);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepo.Add(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        [Route("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var track = _trackRepo.GetById(id);
            if (track == null) return NotFound();
            return View(track);
        }

        [HttpPost]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepo.Update(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        [Route("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            _trackRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}