using Microsoft.Extensions.Logging;
using SalaryPackageCalculator.Models.enums;
using System;
using static System.Console;
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
        private readonly ILogger<Validator> _logger;

        public Validator(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Validator>();
        }
        /// <summary>
        /// This method validate the number by comparing with special caracthers
        /// </summary>
        /// <param name="salaryAmount"></param>
        /// <returns>decimal</returns>
        public decimal ValidateNumber(string salaryAmount)
        {
            decimal result = 0m;
            try
            {
                var invalidCharacters = new Regex("[*'\".,_&#^@]");

                while (invalidCharacters.IsMatch(salaryAmount))
                {
                    Write(Constants.ValidationNumberMessage);
                    salaryAmount = Console.ReadLine();
                }

                result = decimal.Parse(salaryAmount);
            }
            catch (Exception ex)
            {
                _logger.LogTrace($"Validation error: {ex.Message}" );
                WriteLine($"Validation error: {ex.Message}");
            }

            return result;
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
                Write(Constants.ValidationLetterMessage);
                frecuency = ReadLine();
            }

            return frecuency;
        }
    }
}
