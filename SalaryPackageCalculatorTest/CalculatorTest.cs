using Moq;
using NUnit.Framework;
using SalaryPackageCalculator;
using SalaryPackageCalculator.Calculations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryPackageCalculatorTest
{
    public class CalculatorTest
    {
        [Test]
        public void CallCalculatorTest()
        {
            var calculatorMock = new Mock<ICalculator>();

            calculatorMock.Object.Calculate();

            calculatorMock.Verify(x => x.Calculate(), Times.Once);

        }
    }
}
