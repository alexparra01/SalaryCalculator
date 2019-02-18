using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SalaryPackageCalculator.Calculations;
using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using System;


namespace SalaryPackageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dependency injection
            var dependencies = new ServiceCollection()
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

            
            //Calculator initialisation
            var salaryCalculator = dependencies.GetService<ICalculator>();

            //Execute salary calculations
            salaryCalculator.Calculate();

            //Keep the console open
            Console.Read();

        }
    }
}
