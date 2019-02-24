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
    public class MedicareLevyTest
    {
        private IMedicareLevy medicareLevyCalculator;
        private ServiceProvider dependencies;
        private Salary salary;

        public MedicareLevyTest()
        {
            dependencies = new ServiceCollection()
               .AddSingleton<Salary>()
               .AddTransient<IMedicareLevy, MedicareLevy>()
               .BuildServiceProvider();

            salary = dependencies.GetService<Salary>();
            medicareLevyCalculator = dependencies.GetService<IMedicareLevy>();
        }
        /// <summary>
        /// Test Case : This method calculates medicare levy base on a taxableIncome of $59.360.73
        /// </summary>        
       [Test]
        public void CalculateMedicareLevyTest()
        {
            salary.TaxableIncome = 59360.73m;

            medicareLevyCalculator.Calculate();

            Assert.AreEqual(1188.00m, salary.MedicareLevy);
        }

        /// <summary>
        /// Test Case: This method-test calculate Medicare Levy for salaries less than $21,335, the result has to be $0
        /// </summary>
        [Test]
        public void CalculateLevyForTILessThanTwentyOneThousand()
        {
            salary.TaxableIncome = 21335m;

            medicareLevyCalculator.Calculate();

            Assert.AreEqual(0, salary.MedicareLevy);
        }

        /// <summary>
        /// Test Case: This method-test calculate Medicare Levy for salaries in the range of $21,336 - $26,668. Those salaries has 10% dedution.
        /// </summary>
        [Test]
        public void CalculateLevyForTIMoreThanTwentyOneThousand()
        {
            salary.TaxableIncome = 21336m;

            medicareLevyCalculator.Calculate();

            Assert.AreEqual(1, salary.MedicareLevy);
        }

    }
}
