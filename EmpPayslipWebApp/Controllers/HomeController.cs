using EmployeeSalaryModel.Models;
using EmployeeSalaryWebApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Linq;

namespace EmpPayslipWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebApiCallerService _webApiCallerService;

        public HomeController()
        {
            if (_webApiCallerService == null)
                _webApiCallerService = new WebApiCallerService();
        }



        public ActionResult Index()
        {
            return View();
        }

        public ViewResult CreatePayslip()
        {
            return View();
        }


        public async Task<ActionResult> GetPayslip([FromBody]Employee emp)
        {
            if (ModelState.IsValid)
            {
                Payslip payslip = null;

                payslip = await _webApiCallerService.WebApiCallerPost<Employee, Payslip>("api/Payslip", emp);
                if (payslip == null)
                    return View("Index");

                return View(payslip);
            }
            else
            {
                //ViewBag.ErrorMessage = String.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage));
                return View("CreatePayslip");
            }
           

        }

    }
}