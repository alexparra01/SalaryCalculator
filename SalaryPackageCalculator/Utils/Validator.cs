using SalaryPackageCalculator.Models.enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SalaryPackageCalculator.Utils
{
    public interface IValidator
    {
        decimal ValidateNumber(string salaryAmount);
        string ValidateFrecuencyLetter(string frecuency);
    }
    public class Validator : IValidator
    {
        /// <summary>
        /// This method validate the number by comparing with special caracthers
        /// </summary>
        /// <param name="salaryAmount"></param>
        /// <returns>decimal</returns>
        public decimal ValidateNumber(string salaryAmount)
        {
            var invalidCharacters = new Regex("[*'\".,_&#^@]");

            while(invalidCharacters.IsMatch(salaryAmount))
            {
                Console.Write("Wrong input number please enter an salary amount without spaces or special characters ");
                salaryAmount = Console.ReadLine();
            }

            return decimal.Parse(salaryAmount);
        }

        /// <summary>
        /// This method validate that the user enter the correct frecuency (W for weekly, F for fortnightly, M for monthly)
        /// </summary>
        /// <param name="frecuency"></param>
        /// <returns>string</returns>
        public string ValidateFrecuencyLetter(string frecuency)
        {
            while (!string.Equals(frecuency.ToUpper(), "M") && !string.Equals(frecuency.ToUpper(), "F") && !string.Equals(frecuency.ToUpper(), "W"))
            {
                Console.Write("Wrong input letter please enter an frecuency letther without spaces or special characters (W for weekly, F for fortnightly, M for monthly)  ");
                frecuency = Console.ReadLine();
            }

            return frecuency;
        }
    }
}
