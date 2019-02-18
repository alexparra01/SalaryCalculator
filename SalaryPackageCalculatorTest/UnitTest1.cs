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
    public class Tests
    {
        private Mock<ICalculator> _calculatorMock;
        private ICalculator _salaryCalculator;
        private ServiceProvider dependencies;


        [SetUp]
        public void Setup()
        {
            _calculatorMock = new Mock<ICalculator>();
            dependencies = new ServiceCollection()
              .AddLogging(builder => builder.AddConsole()
                .AddFilter(level => level >= LogLevel.Debug))
                .AddSingleton<Salary>()
                .AddTransient<ICalculator, Calculator>()
                .AddTransient<ISuperannuation, Superannuation>()
                .AddTransient<ITaxableIncome, TaxableIncome>()
                .AddTransient<IValidator, Validator>()
                .AddTransient<IDeductions, Deductions>()
                .AddTransient<IMedicareLevy, MedicareLevy>()
                .AddTransient<IBudgetRepairLevy, BudgetRepairLevy>()
                .AddTransient<IIncomeTax, IncomeTax>()
                .AddTransient<INetIncome, NetIncome>()
                .AddTransient<IPayPacket, PayPacket>()
                .BuildServiceProvider();
              

           
        }

        [Test]
        public void Test1()
        {
            _salaryCalculator = dependencies.GetService<ICalculator>();

            _calculatorMock.Verify(x => x.Calculate());

        }
    }
}