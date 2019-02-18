using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Calculations
{
    public interface INetIncome
    {
        void Calculate();
    }

    public class NetIncome : INetIncome
    {
        private Salary _salary;

        public NetIncome(Salary salary)
        {
            _salary = salary;
        }
        /// <summary>
        /// This method calculates net income applying all deductions
        /// </summary>
        public void Calculate()
        {
            _salary.NetIncome = _salary.Amount - _salary.Superannuation - _salary.IncomeTax - _salary.MedicareLevy - _salary.BudgetRepairLevy;

            Console.WriteLine(string.Format(Constants.NetIncomeMessage + "{0}", string.Format("{0:C}", _salary.NetIncome)));
            
        }
    }
}
