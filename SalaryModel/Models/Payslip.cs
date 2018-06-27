using System;

namespace EmployeeSalaryModel.Models
{
    public class Payslip
    {
        
        public string FullName { get; set; }

        public string PayPeriod { get; set; }
      
        public double GrossIncome { get; set; }
       
        public double IncomeTax { get; set; }
        
        public double NetIncome { get; set; }
    
        public double SuperAnnuation { get; set; }

    }
}