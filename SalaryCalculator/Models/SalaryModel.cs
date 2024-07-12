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
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please select company")]
        public CompanyType Company { get; set; }
        [Required(ErrorMessage = "Please select work")]
        public WorkType Work { get; set; }
        [Required(ErrorMessage = "Education required")]
        public bool IsDegree { get; set; }
        [Required(ErrorMessage = "Please enter salary")]
        public int Salary { get; set; }

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
            Casual
        }
    }
}
