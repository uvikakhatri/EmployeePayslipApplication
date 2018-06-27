using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeSalaryModel.Utility;

namespace EmployeeSalaryModel.Models
{
    public class Employee
    {
        [Display(Name = "First Name"), Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Display(Name = "Annual Salary")]
        [Required(ErrorMessage = "Annual Salary is required")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public int AnnualSalary { get; set; }


        [Display(Name = "Super Rate"), Required(ErrorMessage = "Super rate is required")]
        [Range(0, 12, ErrorMessage = "Enter Super rate between 0 to 12")]
        public int SuperRate { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = Global.DataFormatString)]
        public DateTime StartDate { get; set; }
    }
}
