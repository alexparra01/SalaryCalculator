using SalaryPackageCalculator.Models.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculator.Utils
{
    public static class Mapper
    {
        /// <summary>
        /// This method conver the string frencuency to frecuency enum
        /// </summary>
        /// <param name="frecuency"></param>
        /// <returns>Enum</returns>
        public static Frecuency Convert(string frecuency)
        {
            switch (frecuency.ToUpper())
            {
                case "M":
                    return Frecuency.Monthly;
                case "F":
                    return Frecuency.Fornightly;
                case "W":
                    return Frecuency.Weekly;
                default:
                    return Frecuency.Weekly;
            }
        }
    }
}
