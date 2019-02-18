using SalaryPackageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Calculations
{
    public interface IDeductions
    {
        void CalculateMedicareLevy();
        void CalculateBudgetRepairLevy();
        void CalculateIncomeTax();
    }
    /// <summary>
    /// This class encapsulate deductions 
    /// </summary>
    public class Deductions : IDeductions
    {
        private readonly IMedicareLevy _medicareLevy;
        private readonly IBudgetRepairLevy _budgetRepairLevy;
        private readonly IIncomeTax _incomeTax;

        public Deductions(IMedicareLevy medicareLevy, IBudgetRepairLevy budgetRepairLevy, IIncomeTax incomeTax)
        {
            _medicareLevy = medicareLevy;
            _budgetRepairLevy = budgetRepairLevy;
            _incomeTax = incomeTax;
        }

        public void CalculateBudgetRepairLevy()
        {
            _budgetRepairLevy.Calculate();   
        }

        public void CalculateIncomeTax()
        {
            _incomeTax.Calculate();
        }

        public void CalculateMedicareLevy()
        {
            _medicareLevy.Calculate();
        }
    }
}
