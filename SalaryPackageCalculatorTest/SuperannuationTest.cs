using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using SalaryPackageCalculator.Calculations;
using SalaryPackageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculatorTest
{
    public class SuperannuationTest
    {
        private ISuperannuation superCalculator;
        private ServiceProvider dependencies;
        private Salary salary;

        public SuperannuationTest()
        {
            dependencies = new ServiceCollection()
              .AddSingleton<Salary>()
              .AddTransient<ISuperannuation, Superannuation>()
              .BuildServiceProvider();

            salary = dependencies.GetService<Salary>();
            superCalculator = dependencies.GetService<ISuperannuation>();
        }

        /// <summary>
        /// Test Case: Calculate superannuation base on salary gross of 65000 and it has to round it up.
        /// </summary>
        [Test]
        public void CalculateTaxableIncomeTest()
        {
            salary.Amount = 65000m;

            superCalculator.Calculate();

            Assert.IsNotNull(salary.Superannuation);
            Assert.AreEqual(5639.27m, decimal.Round(salary.Superannuation, 2));
        }
    }
}
