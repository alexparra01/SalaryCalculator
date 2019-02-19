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
        private Mock<ITaxableIncome> _calculatorMock;
        private ServiceProvider dependencies;

        public TaxableIncomeTest()
        {
            dependencies = new ServiceCollection()
               .AddSingleton<Salary>()
               .AddTransient<ITaxableIncome, TaxableIncome>()
               .BuildServiceProvider();

            _calculatorMock = new Mock<ITaxableIncome>();
        }

        [Test]
        public void CallTaxableIncomeTest()
        {
            _calculatorMock.Object.Calculate();

            _calculatorMock.Verify(x => x.Calculate(), Times.Once);

        }

        [Test]
        public void CalculateTaxableIncomeTest()
        {
            var taxableCalculator = dependencies.GetService<ITaxableIncome>();
            var salary = dependencies.GetService<Salary>();

            salary.Amount = 65000m;
            salary.Superannuation = 5639.27m;

            taxableCalculator.Calculate();

            Assert.IsNotNull(salary.TaxableIncome);
            Assert.AreEqual(59360, salary.TaxableIncome);
        }
    }
}