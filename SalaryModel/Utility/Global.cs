using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryModel.Utility
{
    public class Global
    {
        public  const string DataFormatString = "dd MMM yyyy";

        public static string GetDateRange(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1).Date;
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var endDate = new DateTime(date.Year, date.Month, daysInMonth).Date;
            return string.Join("-", startDate.ToString(DataFormatString), endDate.ToString(DataFormatString));
        }
        public enum TaxMethod
        {
            Austerlia,
            India
        }
    }


}
