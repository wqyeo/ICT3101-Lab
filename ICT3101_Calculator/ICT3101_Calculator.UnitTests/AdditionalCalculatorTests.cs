using Moq;

namespace ICT3101_Calculator.UnitTests
{
    [TestFixture]
    public class AdditionalCalculatorTests
    {
        private Calculator _calculator;
        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();

            // Return mock data matching MagicNumbers.txt
            _mockFileReader.Setup(fr => fr.Read(It.IsAny<string>()))
                .Returns(new string[]
                {
                    "42",         // Line 0
                    "420",        // Line 1
                    "69",         // Line 2
                    "1337",       // Line 3
                    "2056",       // Line 4
                    "80085",      // Line 5
                    "123456789",  // Line 6
                    "720",        // Line 7
                    "180",        // Line 8
                    "360"         // Line 9
                });

            // Simulate FileNotFoundException for a specific file
            _mockFileReader.Setup(fr => fr.Read("NonExistentFile.txt"))
                .Throws<FileNotFoundException>();

            _calculator = new Calculator();
        }

        #region Magic Number Tests

        [Test]
        [TestCase(0, 84)]        // 2 * 42
        [TestCase(1, 840)]       // 2 * 420
        [TestCase(2, 138)]       // 2 * 69
        [TestCase(3, 2674)]      // 2 * 1337
        [TestCase(4, 4112)]      // 2 * 2056
        [TestCase(5, 160170)]    // 2 * 80085
        [TestCase(6, 246913578)] // 2 * 123456789
        [TestCase(7, 1440)]      // 2 * 720
        [TestCase(8, 360)]       // 2 * 180
        [TestCase(9, 720)]       // 2 * 360
        public void GenMagicNum_WithValidInput_ReturnsExpectedResultParameterized(double input, double expectedValue)
        {
            // Arrange
            string filePath = "MagicNumbers.txt";
            IFileReader fileReader = _mockFileReader.Object;

            // Act
            double result = _calculator.GenMagicNum(input, fileReader, filePath);

            // Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GenMagicNum_WithInputOutOfRangeHigh_ReturnsZero()
        {
            // Arrange
            double input = 100; // Assuming your file has fewer than 100 lines
            string filePath = "MagicNumbers.txt";
            IFileReader fileReader = _mockFileReader.Object;

            // Act
            double result = _calculator.GenMagicNum(input, fileReader, filePath);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GenMagicNum_WithNegativeInput_ReturnsZero()
        {
            // Arrange
            double input = -1;
            string filePath = "MagicNumbers.txt";
            IFileReader fileReader = _mockFileReader.Object;

            // Act
            double result = _calculator.GenMagicNum(input, fileReader, filePath);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GenMagicNum_WithNonIntegerInput_ThrowsArgumentException()
        {
            // Arrange
            double input = 1.5; // Non-integer value
            string filePath = "MagicNumbers.txt";
            IFileReader fileReader = _mockFileReader.Object;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _calculator.GenMagicNum(input, fileReader, filePath));
        }

        [Test]
        public void GenMagicNum_WithMissingFile_ThrowsFileNotFoundException()
        {
            // Arrange
            double input = 1;
            string filePath = "NonExistentFile.txt";
            IFileReader fileReader = _mockFileReader.Object;

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() =>
                _calculator.GenMagicNum(input, fileReader, filePath));
        }

        #endregion
    }
}
