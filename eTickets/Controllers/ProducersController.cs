using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContex _context;

        public ProducersController(AppDbContex contex)
        {
            _context = contex;

        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _context.Producers.ToArrayAsync();
          
            return View(allProducers);
        }
    }
}
