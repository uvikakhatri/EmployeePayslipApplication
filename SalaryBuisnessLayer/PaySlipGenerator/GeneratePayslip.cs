using System;
using EmployeeSalaryContract;
using EmployeeSalaryModel.Models;
using EmployeeSalaryModel.Utility;

namespace EmployeeSalaryBuisness
{
    public class GeneratePayslip : IGeneratePayslip
    {
        Payslip payCheck;
        public GeneratePayslip()
        {
            payCheck = new Payslip();
        }

        public Payslip GenerateEmployeePayslip(Employee employee)
        {
            // Payslip payCheck = new Payslip();
            payCheck.FullName = string.Join(" ", employee.FirstName, employee.LastName);
            payCheck.PayPeriod = Global.GetDateRange(employee.StartDate);
            this.CalculateGrossIncome(employee.AnnualSalary);
            payCheck.IncomeTax = calculateTax(employee.AnnualSalary);
            this.CalculateNetIncome();
            this.CalculateSuperAnnuation(employee.SuperRate);
            return payCheck;
        }

      

        public void CalculateGrossIncome(int annualSalary)
        {
            payCheck.GrossIncome = annualSalary / 12.0;
            payCheck.GrossIncome = Math.Round(payCheck.GrossIncome, MidpointRounding.AwayFromZero);
        }
        
        public void CalculateNetIncome()
        {
            payCheck.NetIncome = (payCheck.GrossIncome - payCheck.IncomeTax);
            payCheck.NetIncome = Math.Round(payCheck.NetIncome, MidpointRounding.AwayFromZero);
        }


        public void CalculateSuperAnnuation(int superRate)
        {
            payCheck.SuperAnnuation = (payCheck.GrossIncome * superRate)/100.0;
            payCheck.SuperAnnuation = Math.Round(payCheck.SuperAnnuation, MidpointRounding.AwayFromZero);
        }


       
        public double calculateTax(int annualSalary)
        {
            // var payslip = (new PayslipFactory(this.TaxYear)).CreatePayslip(taxableEmployee);
            double incomeTax=0;
            double minimumTax = 0;
            double addOnTaxPerDoller = 0;
            int minimumTaxableIncome = 0;
            bool isNotTaxble = false;

            switch (annualSalary)
            {
                case int salary when (salary < 18200):
                default:
                    isNotTaxble = true;
                    break;
                case int salary when (salary > 18200 && salary < 37000):
                    minimumTax = 0;
                    addOnTaxPerDoller = 0.19;
                    minimumTaxableIncome = 18201;                    
                    break;
                case int salary when (salary > 37000 && salary < 87000):
                    minimumTax = 3572;
                    addOnTaxPerDoller = 0.325;
                    minimumTaxableIncome = 37000;
                    break;
                case int salary when (salary > 87000 && salary < 180000):
                    minimumTax = 19822;
                    addOnTaxPerDoller = 0.37;
                    minimumTaxableIncome = 87000;
                    break;
                case int salary when (salary > 180000):
                    minimumTax = 54232;
                    addOnTaxPerDoller = 0.45;
                    minimumTaxableIncome = 180000;
                    break;
            }

            incomeTax = isNotTaxble?0: Math.Round((minimumTax + (annualSalary - minimumTaxableIncome) * addOnTaxPerDoller) / 12.0, MidpointRounding.AwayFromZero);

            return incomeTax;
        }
    }
}
