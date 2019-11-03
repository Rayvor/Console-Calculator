using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp13;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp13.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        Calculator _calculator;

        [TestInitialize()]
        public void Initialize()
        {
            _calculator = new Calculator();
        }

        [DataTestMethod()]
        [DataRow("2+2","2 2 +")]
        [DataRow("1", "1")]
        [DataRow("2-3*4", "2 3 4 * -")]
        [DataRow("1-3*3+7", "1 3 3 * - 7 +")]
        [DataRow("1+3*3-7", "1 3 3 * + 7 -")]
        [DataRow("1+3*3+7", "1 3 3 * + 7 +")]
        [DataRow("3-(1+2)*3-7^2", "3 1 2 + 3 * - 7 2 ^ -")]
        public void IsPostfixEquals(string input, string postfix)
        {
            string calculatedPostfix = _calculator.ConvertToPostfix(input);
            Assert.AreEqual(calculatedPostfix, postfix);
        }

        [DataTestMethod()]
        [DataRow("2 2 +", 4)]
        [DataRow("1", 1)]
        [DataRow("2 3 4 * -", -10)]
        [DataRow("1 3 3 * - 7 +", -1)]
        [DataRow("1 3 3 * + 7 -", 3)]
        [DataRow("1 3 3 * + 7 +", 17)]
        [DataRow("3 1 2 + 3 * - 7 2 ^ -", -55)]
        public void IsResultEquals(string postfix, double result)
        {
            double calculatedResult = _calculator.Calculate(postfix);
            Assert.AreEqual(calculatedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException), "Need to throw exception.")]
        public void TestInvalidInput()
        {
            var calculator = new Calculator();
            string input = "a";
            string postfix = calculator.ConvertToPostfix(input);
            double result = calculator.Calculate(postfix);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException), "Need to throw exception.")]
        public void TestEmptyInput()
        {
            var calculator = new Calculator();
            string input = "";
            string postfix = calculator.ConvertToPostfix(input);
            double result = calculator.Calculate(postfix);
        }
    }
}