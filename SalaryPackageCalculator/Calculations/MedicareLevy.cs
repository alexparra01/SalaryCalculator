
using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SalaryPackageCalculator.Calculations
{
    public interface IMedicareLevy
    {
        void Calculate();
    }
    public class MedicareLevy : IMedicareLevy
    {
        private Salary _salary;
        

        public MedicareLevy(Salary salary)
        {
            _salary = salary;
        }
        /// <summary>
        /// This method calculate medicare levy base on the taxable income.
        /// </summary>
        public void Calculate()
        {
            switch (GetValueInRange(_salary.TaxableIncome))
            {
                case 0:
                    _salary.MedicareLevy = 0m;
                    break;
                case 1:
                    _salary.MedicareLevy = Math.Ceiling((_salary.TaxableIncome - 21335m) * 0.10m);
                    break;
                case 2:
                    _salary.MedicareLevy = Math.Ceiling(0.02m * _salary.TaxableIncome);
                    break;
                default:
                    break;
            }

            WriteLine($"{Constants.MedicareLevyMessage}{_salary.MedicareLevy.ToString("C2")}");

        }

        private int GetValueInRange(decimal taxableIncome)
        {
            if (taxableIncome >= 21336m && taxableIncome <= 26668m) return 1;

            if (taxableIncome >= 26669m) return 2;

            return 0;
        }
    }
}
