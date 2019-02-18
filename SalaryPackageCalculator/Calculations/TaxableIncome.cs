using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Calculations
{
    public interface ITaxableIncome
    {
        void Calculate();
    }

    public class TaxableIncome : ITaxableIncome
    {
        private Salary _salary;

        public TaxableIncome(Salary salary)
        {
            _salary = salary;
        }

        /// <summary>
        /// This method calculate the taxable income by sustracting the superannuation from salary gross
        /// </summary>
        public void Calculate()
        {
            _salary.TaxableIncome = Math.Floor(_salary.Amount - _salary.Superannuation);

            //not rounded taxable income
            var taxableIncome = _salary.Amount - _salary.Superannuation;

            Console.WriteLine(string.Format(Constants.TaxableIncomeMessage + "{0}", string.Format("{0:C}", taxableIncome)));
        }
        
    }
}
