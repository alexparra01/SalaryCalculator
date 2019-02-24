using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Utils
{
    public static class Constants
    {
        public const string EnterSalaryMessage = "Enter your salary package amount: ";
        public const string EnterFrecuencyMessage = "Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ";
        public const string CalculatingSalaryMessage = "Calculating salary details...";
        public const string GrossPackageMessage = "Gross package: ";
        public const string TaxableIncomeMessage = "Taxable income: ";
        public const string SuperannuationMessage = "Superannuation: ";
        public const string DeductionsMessage = "Deductions: ";

        public const string MedicareLevyMessage = "Medicare Levy: ";
        public const string BudgetRepairLevyMessage = "Budget Repair Levy: ";
        public const string IncomeTaxMessage = "Income Tax: ";
        public const string NetIncomeMessage = "Net income: ";
        public const string PayPacketMessage = "Pay packet: ";
        public const string FinishMessage = "Press any key to end...";

        public const string ValidationLetterMessage = "Wrong input letter please enter an frecuency letther without spaces or special characters (W for weekly, F for fortnightly, M for monthly)  ";
        public const string ValidationNumberMessage = "Wrong input number please enter an salary amount without spaces or special characters ";
    }
}
