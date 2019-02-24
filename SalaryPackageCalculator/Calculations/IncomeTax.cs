using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Calculations
{
    public interface IIncomeTax
    {
        void Calculate();
    }
    public class IncomeTax : IIncomeTax
    {
        private Salary _salary;

        public IncomeTax(Salary salary)
        {
            _salary = salary;
        }

        /// <summary>
        /// This method calcualtes the income tax base on the taxable income brakets.
        /// </summary>
        public void Calculate()
        {
            switch (GetValueInRange(_salary.TaxableIncome))
            {
                case 0:
                    _salary.IncomeTax = 0m;
                    break;
                case 1:
                    _salary.IncomeTax = Math.Ceiling((_salary.TaxableIncome - 18200m) * 0.19m);
                    break;
                case 2:
                    _salary.IncomeTax = Math.Ceiling(3572m + ((_salary.TaxableIncome - 37000m) * 0.325m));
                    break;
                case 3:
                    _salary.IncomeTax = Math.Ceiling(19822m + ((_salary.TaxableIncome - 87000m) * 0.37m));
                    break;
                case 4:
                    _salary.IncomeTax = Math.Ceiling(54232m + ((_salary.TaxableIncome - 180000m) * 0.47m));
                    break;
                default:
                    break;
            }

            WriteLine($"{Constants.IncomeTaxMessage}{_salary.IncomeTax.ToString("C2")}");
        }

        private int GetValueInRange(decimal taxableIncome)
        {
            if (taxableIncome >= 18201m && taxableIncome <= 37000m) return 1;

            if (taxableIncome >= 37001m && taxableIncome <= 87000m) return 2;

            if (taxableIncome >= 87001m && taxableIncome <= 180000m) return 3;

            if (taxableIncome >= 180001m) return 4;

            return 0;
        }
    }
}
