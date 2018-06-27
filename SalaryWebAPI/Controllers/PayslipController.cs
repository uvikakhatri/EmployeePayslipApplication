using EmployeeSalaryBuisness;
using EmployeeSalaryContract;
using EmployeeSalaryModel.Models;
using System.Net.Http;
using System.Web.Http;
using static EmployeeSalaryModel.Utility.Global;

namespace EmployeeSalaryWebAPI.Controllers
{
    public class PayslipController : ApiController
    {
       
        public PayslipController()
        {

        }
       

        // Post api/<controller>
        public IHttpActionResult CreatePaySlip(Employee employee)
        {
            if (!ModelState.IsValid || employee != null)
            {
                PayslipAbstractFactory payslipFactory = new PayslipFactory();
                var payslip = payslipFactory.GetPaySlip(TaxMethod.Austerlia);
                return Ok(payslip.GenerateEmployeePayslip(employee));

            }
            else
            {
                return NotFound();
            }
        }
    }

}