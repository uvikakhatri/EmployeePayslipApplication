using EmployeeSalaryContract;
using EmployeeSalaryModel.Models;
using static EmployeeSalaryModel.Utility.Global;

namespace EmployeeSalaryBuisness
{
    public class PayslipFactory: PayslipAbstractFactory
    {
        public override IGeneratePayslip GetPaySlip(TaxMethod method)
        {
            switch (method)
            {
                case TaxMethod.Austerlia:
                default:
                   return new GeneratePayslip();
            }
        }
     }
}
