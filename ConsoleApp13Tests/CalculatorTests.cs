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
        [TestMethod()]
        public void ConvertToPostfixTest()
        {
            var calculator = new Calculator();
            string input = "2+2";

            string postfix = calculator.ConvertToPostfix(input);
            string postfixCheck = "2 2 +";
            Assert.AreEqual(postfix, postfixCheck);
            double result = calculator.Calculate(postfix);
            double resultCheck = 4;
            Assert.AreEqual(result, resultCheck);

            input = "1";

            postfix = calculator.ConvertToPostfix(input);
            postfixCheck = "1";
            Assert.AreEqual(postfix, postfixCheck);
            result = calculator.Calculate(postfix);
            resultCheck = 1;
            Assert.AreEqual(result, resultCheck);

            input = "2-3*4";

            postfix = calculator.ConvertToPostfix(input);
            postfixCheck = "2 3 4 * -";
            Assert.AreEqual(postfix, postfixCheck);
            result = calculator.Calculate(postfix);
            resultCheck = -10;
            Assert.AreEqual(result, resultCheck);

            input = "1-3*3+7";

            postfix = calculator.ConvertToPostfix(input);
            postfixCheck = "1 3 3 * - 7 +";
            Assert.AreEqual(postfix, postfixCheck);
            result = calculator.Calculate(postfix);
            resultCheck = -1;
            Assert.AreEqual(result, resultCheck);

            input = "1+3*3+7";

            postfix = calculator.ConvertToPostfix(input);
            postfixCheck = "1 3 3 * + 7 +";
            Assert.AreEqual(postfix, postfixCheck);
            result = calculator.Calculate(postfix);
            resultCheck = 17;
            Assert.AreEqual(result, resultCheck);

            input = "1+3*3-7";

            postfix = calculator.ConvertToPostfix(input);
            postfixCheck = "1 3 3 * + 7 -";
            Assert.AreEqual(postfix, postfixCheck);
            result = calculator.Calculate(postfix);
            resultCheck = 3;
            Assert.AreEqual(result, resultCheck);

            input = "2^2*2+2";

            postfix = calculator.ConvertToPostfix(input);
            postfixCheck = "2 2 ^ 2 * 2 +";
            Assert.AreEqual(postfix, postfixCheck);
            result = calculator.Calculate(postfix);
            resultCheck = 10;
            Assert.AreEqual(result, resultCheck);

            input = "3-(1+2)*3-7^2";

            postfix = calculator.ConvertToPostfix(input);
            postfixCheck = "3 1 2 + 3 * - 7 2 ^ -";
            Assert.AreEqual(postfix, postfixCheck);
            result = calculator.Calculate(postfix);
            resultCheck = -55;
            Assert.AreEqual(result, resultCheck);
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