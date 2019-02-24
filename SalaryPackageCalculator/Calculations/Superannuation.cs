using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using System;
using static System.Console;
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
            WriteLine($"{Constants.SuperannuationMessage}{_salary.Superannuation.ToString("C2")}");
        } 
        
    }
}
