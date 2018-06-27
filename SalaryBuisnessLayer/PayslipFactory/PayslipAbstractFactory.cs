using EmployeeSalaryContract;
using EmployeeSalaryModel.Models;
using static EmployeeSalaryModel.Utility.Global;

namespace EmployeeSalaryBuisness
{
    public abstract class PayslipAbstractFactory
    {
        public abstract IGeneratePayslip GetPaySlip(TaxMethod method);
    }
}
