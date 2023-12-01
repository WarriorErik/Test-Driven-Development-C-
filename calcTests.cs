using strinCalcTDD;



namespace StringCalculatorTests
{
    [TestClass]
    public class calcTests
    {
        private StringCalculator _calculator;

        [TestMethod]
        [TestInitialize]
        public void TestInitialize()
        {
            //Arranges for all tests
            _calculator = new StringCalculator();
        }

        [TestMethod]
        public void AddEmptyStringReturnsZero()
        {
            //Act; Arrange or instantiation already done with use of _calculator field 
            int result = _calculator.Add("");

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AddSingleNumberReturnsNumber()
        {
            //Act; Arrange or instantiation already done with use of _calculator field 
            int result = _calculator.Add("1");

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void AddTwoNumbersReturnsSum()
        {
            //Act
            int result = _calculator.Add("1,2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddUnknownAmountOfNumbersReturnsSum()
        {
            //Act
            int result = _calculator.Add("1,2,3,4,5");

            //Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void AddNewLineDelimiterReturnsSum()
        {
            int result = _calculator.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AddCustomDelimiterReturnsSum()
        {
            //Act
            int result = _calculator.Add("//;\n1;2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddNumberGreaterThan1000IgnoredInSum()
        {
            //Act
            int result = _calculator.Add("2,1001");

            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void AddLongCustomDelimiterReturnsSum()
        {
            //Act
            int result = _calculator.Add("//[---]\n1---2---3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AddMultipleCustomDelimitersReturnsSum()
        {
            //Act
            int result = _calculator.Add("//[-][%]\n1-2%3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AddMultipleLongCustomDelimitersReturnsSum()
        {
            //Act
            int result = _calculator.Add("//[**][%%]\n1**2%%3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNegativeNumberThrowsException()
        {
            //Act; Assert not needed for negative tests
            _calculator.Add("1,-2,3");
        }
    }
}