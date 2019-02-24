using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Models.enums;
using SalaryPackageCalculator.Utils;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Calculations
{
    public interface IPayPacket
    {
        void Calculate();
    }
    public class PayPacket : IPayPacket
    {
        private Salary _salary;
        private string frecuency = string.Empty;
        public PayPacket(Salary salary)
        {
            _salary = salary;
        }

        /// <summary>
        /// This Method calculate salary payment monthly, fornightly and weekly.
        /// </summary>
        public void Calculate()
        {
            switch (_salary.Frecuency)
            {
                case Frecuency.Weekly:
                    _salary.PayPacket = (_salary.NetIncome / 365m) * 7m;
                    frecuency = " per week";
                    break;
                case Frecuency.Fornightly:
                    _salary.PayPacket = (_salary.NetIncome / 365m) * 14m;
                    frecuency = " per fornightly";
                    break;
                case Frecuency.Monthly:
                    _salary.PayPacket = _salary.NetIncome / 12m;
                    frecuency = " per month";
                    break;
                default:
                    break;
            }
            WriteLine($"{Constants.PayPacketMessage}{_salary.PayPacket.ToString("C2")}{frecuency}");
        }
    }
}
