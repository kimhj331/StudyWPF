﻿using System;
using CalcApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestAdd3and7()
        {
            //예상결과 3 + 7 = 10
            double a = 3.0;
            double b = 7.0;
            double expected = 10.0;

            Calculator calc = new Calculator();
            double actual = calc.Add(a, b);

            //두개 값이 같은지 아닌지 판단
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMulple4and5()
        {
            //4*5=20
            double a = 4.0;
            double b = 5.0;
            double expected = 20.0;

            Calculator calc = new Calculator();
            double actual = calc.Multiple(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDivide10and2()
        {
            // 10 / 2 =5
            double a = 10.0;
            double b = 2.0;
            double expected = 5.0;

            Calculator calc = new Calculator();
            double actual = calc.Divide(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
