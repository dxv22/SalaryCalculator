using System.ComponentModel.DataAnnotations;

namespace SalaryCalculator.Models
{
    public class SalaryModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        [RegularExpression(@"^04\d{8}$", ErrorMessage = "Please enter a valid phone number e.g. 0411111111")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please select company")]
        public CompanyType Company { get; set; }
        [Required(ErrorMessage = "Please select work")]
        public WorkType Work { get; set; }
        [Required(ErrorMessage = "Hours worked required")]
        [Range(0, 38, ErrorMessage = "Please enter valid hours worked from 0-38 hours")]
        public int HoursWorked { get; set; }
        [Required(ErrorMessage = "Education required")]
        public bool IsDegree { get; set; }
        [Required(ErrorMessage = "Please enter salary")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid salary")]
        public double Salary { get; set; }

        public enum CompanyType
        {
            Corporate,
            Hospital,
            PBI
        }

        public enum WorkType
        {
            [Display(Name = "Full-time")]
            FullTime,
            [Display(Name = "Part-time")]
            PartTime,
            [Display(Name = "Casual")]
            Casual
        }
    }
}
