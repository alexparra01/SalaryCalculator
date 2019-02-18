using SalaryPackageCalculator.Models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Models
{
    public class Salary
    {
        public decimal Amount { get; set; }
        public Frecuency Frecuency { get; set; }
        public decimal Superannuation { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal MedicareLevy { get; set; }
        public decimal BudgetRepairLevy { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal PayPacket { get; set; }

    }
}
