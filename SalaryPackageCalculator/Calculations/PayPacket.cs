using SalaryPackageCalculator.Models;
using SalaryPackageCalculator.Models.enums;
using SalaryPackageCalculator.Utils;
using System;
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
                    Console.WriteLine(string.Format(Constants.PayPacketMessage + "{0}" + " per week", string.Format("{0:C}", _salary.PayPacket)));
                    break;
                case Frecuency.Fornightly:
                    _salary.PayPacket = (_salary.NetIncome / 365m) * 14m;
                    Console.WriteLine(string.Format(Constants.PayPacketMessage + "{0}" + " per fornightly", string.Format("{0:C}", _salary.PayPacket)));
                    break;
                case Frecuency.Monthly:
                    _salary.PayPacket = _salary.NetIncome / 12m;
                    Console.WriteLine(string.Format(Constants.PayPacketMessage + "{0}" + " per month", string.Format("{0:C}", _salary.PayPacket)));
                    break;
                default:
                    break;
            }
        }
    }
}
