using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SalaryPackageCalculator.Calculations
{
    public interface ISuperannuation
    {
        void Calculate();
    }
    public class Superannuation : ISuperannuation
    {
        private Salary _salary;

        public Superannuation(Salary salary)
        {
            _salary = salary;
        }

        /// <summary>
        /// This method calculate superannuation base on the gross salary.
        /// </summary>
        public void Calculate()
        {
            _salary.Superannuation = _salary.Amount - _salary.Amount / 1.095m;
            Console.WriteLine(string.Format(Constants.SuperannuationMessage + "{0}", string.Format("{0:C}", _salary.Superannuation)));
        } 
        
    }
}
