using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Models;
using System.Diagnostics;

namespace SalaryCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Index
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Calculate(SalaryModel salary)
        {
            if (!ModelState.IsValid)
            {
                return View(salary);
            }
            else
            {
                // Todo - submit form data
                return RedirectToAction("Index");
            }
        }
    }
}
