using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SalaryPackageCalculator.Calculations;
using SalaryPackageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculatorTest
{ 
    public class BudgetRepairLevyTest
    {
        private IBudgetRepairLevy budgetLevyRepairCalculator;
        private ServiceProvider dependencies;
        private Salary salary;

        public BudgetRepairLevyTest()
        {
            dependencies = new ServiceCollection()
               .AddSingleton<Salary>()
               .AddTransient<IBudgetRepairLevy, BudgetRepairLevy>()
               .BuildServiceProvider();

            salary = dependencies.GetService<Salary>();
            budgetLevyRepairCalculator = dependencies.GetService<IBudgetRepairLevy>();
        }
        /// <summary>
        /// Test Case: This method calculate the budget repair levy when is TI is less than $180,000 
        /// </summary>
        [Test]
        public void CalculateBudgetLevyRepairTest()
        {
            salary.TaxableIncome = 59360.73m;

            budgetLevyRepairCalculator.Calculate();

            Assert.AreEqual(0, salary.BudgetRepairLevy);
        }
        /// <summary>
        /// Test Case: This method calculate the budget repair levy when TI is more than $180,000
        /// </summary>
        [Test]
        public void CalculateBudgetLevyForTIOverHundredAndEightyThousand()
        {
            salary.TaxableIncome = 200000m;

            budgetLevyRepairCalculator.Calculate();

            Assert.AreEqual(400m, salary.BudgetRepairLevy);
        }
    }
}
