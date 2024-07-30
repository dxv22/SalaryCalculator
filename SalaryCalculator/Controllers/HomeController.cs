using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Models;
using SalaryCalculator.Services.Interfaces;

namespace SalaryCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculationService _calculationService;

        public HomeController(ILogger<HomeController> logger, ICalculationService calculationService)
        {
            _logger = logger;
            _calculationService = calculationService;
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
                var totalLimit = _calculationService.CalculateSalaryLimit(salaryModel);

                //return View("Index", salaryModel);
                return View("Index");
            }
        }
    }
}
