using Microsoft.Extensions.Logging;
using SalaryPackageCalculator.Calculations;
using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Utils;
using static System.Console;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SalaryPackageCalculator
{
    public interface ICalculator
    {
        void Calculate();
    }

    public class Calculator : ICalculator
    {
        private readonly ILogger<Calculator> _logger;
        private readonly ISuperannuation _supperannuation;
        private readonly ITaxableIncome _taxableIncome;
        private readonly IValidator _validator;
        private readonly IDeductions _deductions;
        private readonly INetIncome _netIncome;
        private readonly IPayPacket _payPacket;
        private Salary _salary;

        public Calculator(ILoggerFactory loggerFactory,
            ISuperannuation superannuation,
            Salary salary,
            IDeductions deductions,
            ITaxableIncome taxableIncome,
            INetIncome netIncome,
            IPayPacket payPacket,
            IValidator validator)
        {
            _logger = loggerFactory.CreateLogger<Calculator>();
            _supperannuation = superannuation;
            _taxableIncome = taxableIncome;
            _deductions = deductions;
            _salary = salary;
            _validator = validator;
            _netIncome = netIncome;
            _payPacket = payPacket;
        }

        /// <summary>
        /// This method calculate gross salary, superannuation, deductions, net income and pay package.
        /// </summary>
        public void Calculate()
        {
            //Input salary
            Write(Constants.EnterSalaryMessage);
            _salary.Amount = _validator.ValidateNumber(ReadLine());

            //Input frecuency
            Write(Constants.EnterFrecuencyMessage);
            _salary.Frecuency = Mapper.Convert(_validator.ValidateFrecuencyLetter(ReadLine()));

            WriteLine();
            WriteLine(Constants.CalculatingSalaryMessage);
            WriteLine();

            //Print gross salary
            WriteLine($"{Constants.GrossPackageMessage}{_salary.Amount.ToString("C0")}");

            //Calculate superannuation
            _supperannuation.Calculate();
            WriteLine();

            //Calculate taxableincome
            _taxableIncome.Calculate();
            WriteLine();

            //Calculate deductions
            WriteLine(Constants.DeductionsMessage);
            _deductions.CalculateMedicareLevy();
            _deductions.CalculateBudgetRepairLevy();
            _deductions.CalculateIncomeTax();
            WriteLine();

            //Salary after deductions
            _netIncome.Calculate();

            //Salary pay frecuency (monthly, weekly, fornightly)
            _payPacket.Calculate();
            WriteLine();

            WriteLine(Constants.FinishMessage);
           
        }
    }
}
