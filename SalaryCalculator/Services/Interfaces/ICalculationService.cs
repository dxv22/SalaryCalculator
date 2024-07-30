using SalaryCalculator.Models;

namespace SalaryCalculator.Services.Interfaces
{
    public interface ICalculationService
    {
        public decimal CalculateSalaryLimit(SalaryModel details);
    }
}
