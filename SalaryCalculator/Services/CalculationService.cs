using SalaryCalculator.Models;
using SalaryCalculator.Services.Interfaces;

namespace SalaryCalculator.Services
{
    public class CalculationService : ICalculationService
    {
        public double CalculateSalaryLimit(SalaryModel details)
        {
            double salaryLimit = 0;

            switch (details.Company)
            {
                case SalaryModel.CompanyType.Corporate:
                    salaryLimit = CalculateCorporateSalaryLimit(details);
                    break;

                case SalaryModel.CompanyType.Hospital:
                    salaryLimit = CalculateHospitalSalaryLimit(details);
                    break;

                case SalaryModel.CompanyType.PBI:
                    salaryLimit = CalculatePBISalaryLimit(details);
                    break;
            }

            return salaryLimit;
        }

        private static double CalculateCorporateSalaryLimit(SalaryModel details)
        {
            double corporateFTHours = 38;

            double salaryThreshold = 100000;
            double lowSalaryRate = 0.01;
            double highSalaryRate = 0.001;

            double rate = details.Salary > salaryThreshold ? lowSalaryRate : highSalaryRate;

            if (details.Work == SalaryModel.WorkType.Casual)
                return 0;

            if (details.Work == SalaryModel.WorkType.PartTime)
            {
                return details.Salary * (details.HoursWorked / corporateFTHours);
            }

            return details.Salary * rate;
        }

        private static double CalculateHospitalSalaryLimit(SalaryModel details)
        {
            double hospitalLowThreshold = 10000;
            double hospitalHighThreshold = Math.Min(details.Salary * 0.2, 30000);
            double educationBonus = 5000;
            double hospitalFTBonus = 1.095;
            double additionalFTSalaryPercentage = 0.012;
            double salaryLimit = Math.Max(hospitalLowThreshold, hospitalHighThreshold);

            if (details.IsDegree)
            {
                salaryLimit += educationBonus;
            }
                
            if (details.Work == SalaryModel.WorkType.FullTime)
            {
                salaryLimit = salaryLimit * hospitalFTBonus + (details.Salary * additionalFTSalaryPercentage);
            }

            return salaryLimit;
        }

        private static double CalculatePBISalaryLimit(SalaryModel details)
        {
            double salaryLimit; 

            double fullTimeFlatSalaryLimit = 50000;
            double fullTimeSalaryPercentage = 0.3255;
            double casualFlatPercentage = 0.1;
            double partTimePercentage = 0.8;
            double educatedFlatBonus = 2000;
            double educatedPercentageBonus = 0.01;

            double educatedTotalBonus = details.Salary + educatedFlatBonus + (details.Salary * educatedPercentageBonus);

            if (details.Work == SalaryModel.WorkType.Casual)
            {
                salaryLimit =  details.Salary * casualFlatPercentage;
            }
            else
            {
                // Full time pbi limit
                double calculatedFtLimit = Math.Min(fullTimeFlatSalaryLimit, details.Salary * fullTimeSalaryPercentage);

                if (details.Work == SalaryModel.WorkType.PartTime)
                {
                    calculatedFtLimit *= partTimePercentage;
                }

                if (details.IsDegree)
                {
                    double educatedBonus = calculatedFtLimit + educatedFlatBonus + (details.Salary * educatedPercentageBonus);

                    salaryLimit = educatedBonus + calculatedFtLimit;
                }
                else
                {
                    salaryLimit = calculatedFtLimit;
                }
            }

            return salaryLimit;
        }
    }
}
