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

        [HttpGet]
        public IActionResult Index()
        {
            // Index
            var model = new SalaryModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(SalaryModel salaryModel)
        {
            if (!ModelState.IsValid)
            {
                // Return same view with errors
                salaryModel.ShowResult = false;

                return View("Index", salaryModel);
            }
            else
            {
                salaryModel.CalculatedSalaryLimit = _calculationService.CalculateSalaryLimit(salaryModel);
                salaryModel.ShowResult = true;

                return View("Index", salaryModel);
            }
        }
    }
}
