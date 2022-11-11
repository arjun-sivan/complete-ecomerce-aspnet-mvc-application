using Microsoft.AspNetCore.Mvc;
using eTickets.Data;
namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContex _contex;

        public ActorsController(AppDbContex contex)
        {
            _contex = contex;
        }

        public IActionResult Index()
        {
            var data = _contex.Actors.ToList(); 

            return View(data);
        }
    }
}
