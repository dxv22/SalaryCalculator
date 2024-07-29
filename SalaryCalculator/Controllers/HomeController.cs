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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(SalaryModel salaryModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", salaryModel);
            }
            else
            {
                // Todo - submit form data
                return View("Index", salaryModel);
            }
        }
    }
}
