using LottoAPI.Controllers;
using LottoAPI.Models;
using LottoAPI.Services;
using LottoAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LottoAPIUnitTest
{
    [TestClass]
    public class CalculateLineResultUnitTests
    {
        [TestMethod]
        public void GetResult_LineValuesSummedEqualTwo_ReturnTen()
        {
            //Arrange 
            List<int> testList = new List<int>();
            testList.Add(1);
            testList.Add(1);
            testList.Add(0);
            int expected = 10;

            // Act
            var actual = CalculateLineResult.GetResult(testList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetResult_LineValuesAllEqual_ReturnFive()
        {
            //Arrange 
            List<int> testList = new List<int>();
            testList.Add(1);
            testList.Add(1);
            testList.Add(1);
            int expected = 5;

            // Act
            var actual = CalculateLineResult.GetResult(testList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetResult_LineValuesANotEqualToBAndANotEqualToC_ReturnOne()
        {
            //Arrange 
            List<int> testList = new List<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
            int expected = 1;

            // Act
            var actual = CalculateLineResult.GetResult(testList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetResult_LineValuesANotEqualToBAndANotEqualToC_ReturnOne_2()
        {
            //Arrange 
            List<int> testList = new List<int>();
            testList.Add(0);
            testList.Add(2);
            testList.Add(2);
            int expected = 1;

            // Act
            var actual = CalculateLineResult.GetResult(testList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetResult_AllOtherScenarios_ReturnZero()
        {
            //Arrange 
            List<int> testList = new List<int>();
            testList.Add(2);
            testList.Add(2);
            testList.Add(0);
            int expected = 0;

            // Act
            var actual = CalculateLineResult.GetResult(testList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
