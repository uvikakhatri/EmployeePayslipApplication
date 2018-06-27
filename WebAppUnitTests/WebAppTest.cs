using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeSalaryWebAPI.Controllers;
using EmployeeSalaryModel.Models;
using System.Web.Http.Results;
using System.Web.Http;

namespace WebAppUnitTests
{
    [TestClass]
    public class WebAppTest
    {

        [TestMethod]
        public void Test_GetPayslip_1()
        {
            var payslipController = new PayslipController();

            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 60050,
                StartDate = new DateTime(2018, 03, 01),
                SuperRate = 9
            };

            var paySlip = (payslipController.CreatePaySlip(employee) as OkNegotiatedContentResult<Payslip>).Content;

            Assert.IsNotNull(paySlip);
            Assert.AreEqual(5004, paySlip.GrossIncome);
            Assert.AreEqual(922, paySlip.IncomeTax);
            Assert.AreEqual(4082, paySlip.NetIncome);
            Assert.AreEqual(450, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Mar 2018-31 Mar 2018", paySlip.PayPeriod);
        }


        [TestMethod]
        public void Test_GetPayslip_2()
        {
            var payslipController = new PayslipController();

            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 120000,
                StartDate = new DateTime(2018, 03, 15),
                SuperRate = 10
            };

            var paySlip = (payslipController.CreatePaySlip(employee) as OkNegotiatedContentResult<Payslip>).Content;

            Assert.IsNotNull(paySlip);
            Assert.AreEqual(10000, paySlip.GrossIncome);
            Assert.AreEqual(2669, paySlip.IncomeTax);
            Assert.AreEqual(7331, paySlip.NetIncome);
            Assert.AreEqual(1000, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Mar 2018-31 Mar 2018", paySlip.PayPeriod);
        }

        [TestMethod]
        public void Test_GetPayslip_3()
        {
            var payslipController = new PayslipController();

            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 10000,
                StartDate = new DateTime(2018, 06, 30),
                SuperRate = 0
            };

            var paySlip = (payslipController.CreatePaySlip(employee) as OkNegotiatedContentResult<Payslip>).Content;

            Assert.IsNotNull(paySlip);
            Assert.AreEqual(833, paySlip.GrossIncome);
            Assert.AreEqual(0, paySlip.IncomeTax);
            Assert.AreEqual(833, paySlip.NetIncome);
            Assert.AreEqual(0, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Jun 2018-30 Jun 2018", paySlip.PayPeriod);
        }

        [TestMethod]
        public void Test_GetPayslip_4()
        {
            var payslipController = new PayslipController();

            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 20000,
                StartDate = new DateTime(2018, 06, 30),
                SuperRate = 3
            };

            var paySlip = (payslipController.CreatePaySlip(employee) as OkNegotiatedContentResult<Payslip>).Content;

            Assert.IsNotNull(paySlip);
            Assert.AreEqual(1667, paySlip.GrossIncome);
            Assert.AreEqual(28, paySlip.IncomeTax);
            Assert.AreEqual(1639, paySlip.NetIncome);
            Assert.AreEqual(50, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Jun 2018-30 Jun 2018", paySlip.PayPeriod);
        }

        [TestMethod]
        public void Test_GetPayslip_5()
        {
            var payslipController = new PayslipController();

            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = 200000,
                StartDate = new DateTime(2018, 06, 30),
                SuperRate = 3
            };

            var paySlip = (payslipController.CreatePaySlip(employee) as OkNegotiatedContentResult<Payslip>).Content;

            Assert.IsNotNull(paySlip);
            Assert.AreEqual(16667, paySlip.GrossIncome);
            Assert.AreEqual(5269, paySlip.IncomeTax);
            Assert.AreEqual(11398, paySlip.NetIncome);
            Assert.AreEqual(500, paySlip.SuperAnnuation);
            Assert.AreEqual("01 Jun 2018-30 Jun 2018", paySlip.PayPeriod);
        }

        [TestMethod]
        public void NegativeTest_GetPayslip1()
        {
            var payslipController = new PayslipController();
            var result = (payslipController.CreatePaySlip(null));

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        [TestMethod]
        public void NegativeTest_GetPayslip2()
        {
            var payslipController = new PayslipController();

            var employee = new Employee()
            {
                FirstName = "Uvika",
                LastName = "Khatri",
                AnnualSalary = -200,
                StartDate = new DateTime(2018, 06, 30),
                SuperRate = -3
            };

            var result = (payslipController.CreatePaySlip(employee));

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

    }
}
