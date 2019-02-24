using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SalaryPackageCalculator;
using SalaryPackageCalculator.Calculations;
using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;

namespace Tests
{
    public class TaxableIncomeTest
    {
        private ITaxableIncome taxableCalculator;
        private ServiceProvider dependencies;
        private Salary salary;

        public TaxableIncomeTest()
        {
            dependencies = new ServiceCollection()
               .AddSingleton<Salary>()
               .AddTransient<ITaxableIncome, TaxableIncome>()
               .BuildServiceProvider();

            salary = dependencies.GetService<Salary>();
            taxableCalculator = dependencies.GetService<ITaxableIncome>();
        }
       
        /// <summary>
        /// Test Case: Calculate taxable income base on salary gross of 65000 and a super of 5639.27. The expected
        /// result is 59360 (Rounded down)
        /// </summary>
        [Test]
        public void CalculateTaxableIncomeTest()
        {
            salary.Amount = 65000m;
            salary.Superannuation = 5639.27m;

            taxableCalculator.Calculate();

            Assert.IsNotNull(salary.TaxableIncome);
            Assert.AreEqual(59360m, salary.TaxableIncome);
        }
    }
}