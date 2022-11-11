using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContex _context;

        public MoviesController(AppDbContex contex)
        {
            _context = contex;

        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.ToArrayAsync();

            return View(allMovies);
        }
    }
}
