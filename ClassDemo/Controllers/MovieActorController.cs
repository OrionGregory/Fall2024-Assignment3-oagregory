using ClassDemo.Data;
using ClassDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClassDemo.Controllers
{
    public class MovieActorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieActorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieActor
        public async Task<IActionResult> Index()
        {
            var movieActors = _context.MovieActors
                .Include(ma => ma.Movie)
                .Include(ma => ma.Actor);
            return View(await movieActors.ToListAsync());
        }

        // GET: MovieActor/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,ActorId")] MovieActor movieActor)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate ViewData
                ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieActor.MovieId);
                ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Name", movieActor.ActorId);
                return View(movieActor);
            }

            bool alreadyExists = await _context.MovieActors
                .AnyAsync(ma => ma.MovieId == movieActor.MovieId && ma.ActorId == movieActor.ActorId);

            if (alreadyExists)
            {
                ModelState.AddModelError("", "This actor is already linked to the movie.");
                ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieActor.MovieId);
                ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Name", movieActor.ActorId);
                return View(movieActor);
            }

            try
            {
                _context.Add(movieActor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine(ex.Message);
                ModelState.AddModelError("", "An error occurred while saving the link.");
                ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieActor.MovieId);
                ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "Name", movieActor.ActorId);
                return View(movieActor);
            }
        }
    }
}
