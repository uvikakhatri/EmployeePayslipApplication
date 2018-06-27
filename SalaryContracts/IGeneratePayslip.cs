using EmployeeSalaryModel.Models;

namespace EmployeeSalaryContract
{
    public interface  IGeneratePayslip
    {
        Payslip GenerateEmployeePayslip(Employee employee);

    }
}
