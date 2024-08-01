using SalaryCalculator.Models;

namespace SalaryCalculator.Services.Interfaces
{
    public interface ICalculationService
    {
        public double CalculateSalaryLimit(SalaryModel details);
    }
}
