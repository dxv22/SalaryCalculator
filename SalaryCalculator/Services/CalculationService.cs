using SalaryCalculator.Models;
using SalaryCalculator.Services.Interfaces;

namespace SalaryCalculator.Services
{
    public class CalculationService : ICalculationService
    {
        public decimal CalculateSalaryLimit(SalaryModel details)
        {
            switch (details.Company)
            {
                case SalaryModel.CompanyType.Corporate:

                    break;
                case SalaryModel.CompanyType.Hospital:

                    break;
                case SalaryModel.CompanyType.PBI:

                    break;
            }

            return 0;
        }
    }
}
