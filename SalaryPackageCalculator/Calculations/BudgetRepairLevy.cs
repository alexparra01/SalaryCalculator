using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Calculations
{
    public interface IBudgetRepairLevy
    {
        void Calculate();
    }
    public class BudgetRepairLevy : IBudgetRepairLevy
    {
        private Salary _salary;

        public BudgetRepairLevy(Salary salary)
        {
            _salary = salary;
        }
        /// <summary>
        /// This method calculates the salary budget repair levy base on the taxable income brakets.
        /// </summary>
        public void Calculate()
        {
            switch (GetValueInRange(_salary.TaxableIncome))
            {
                case 0:
                    _salary.BudgetRepairLevy = 0m;
                    Console.WriteLine(string.Format(Constants.BudgetRepairLevyMessage + "{0}", string.Format("{0:C0}", _salary.BudgetRepairLevy)));
                    break;
                case 1:
                    _salary.BudgetRepairLevy = Math.Ceiling((_salary.TaxableIncome - 180000m) * 0.02m);
                    Console.WriteLine(string.Format(Constants.BudgetRepairLevyMessage + "{0}", string.Format("{0:C0}", _salary.BudgetRepairLevy)));
                    break;
                default:
                    break;
            }

        }

        private int GetValueInRange(decimal taxableIncome)
        {
            if (taxableIncome >= 180001m) return 1;
        
            return 0;
        }
    }
}
