using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SalaryPackageCalculator.Calculations;
using SalaryPackageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculatorTest
{
    public class IncomeTaxTest
    {
        private IIncomeTax incomeTaxCalculator;
        private ServiceProvider dependencies;
        private Salary salary;

        public IncomeTaxTest()
        {
            dependencies = new ServiceCollection()
               .AddSingleton<Salary>()
               .AddTransient<IIncomeTax, IncomeTax>()
               .BuildServiceProvider();

            salary = dependencies.GetService<Salary>();
            incomeTaxCalculator = dependencies.GetService<IIncomeTax>();
        }
        /// <summary>
        /// Test Case: This method calculate the income tax for a taxable income between $37,001 - $87,000
        /// </summary>
        [Test]
        public void CalculateIncomeTaxTest()
        {
            salary.TaxableIncome = 59360; 

            incomeTaxCalculator.Calculate();

            Assert.AreEqual(10839.00m, salary.IncomeTax);
        }

    }
}
