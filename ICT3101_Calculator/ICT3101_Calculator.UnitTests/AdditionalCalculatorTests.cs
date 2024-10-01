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

            _mockFileReader.Setup(fr => fr.Read(It.IsAny<string>()))
                .Returns(new string[]
                {
                    "42",
                    "420",
                    "69",
                    "1337",
                    "2056",
                    "80085",
                    "123456789",
                    "720",
                    "-180",
                    "-360" 
                });

            _mockFileReader.Setup(fr => fr.Read("NonExistentFile.txt"))
                .Throws<FileNotFoundException>();

            _calculator = new Calculator();
        }


        [Test]
        [TestCase(0, 84)]        // 2 * 42
        [TestCase(1, 840)]       // 2 * 420
        [TestCase(2, 138)]       // 2 * 69
        [TestCase(3, 2674)]      // 2 * 1337
        [TestCase(4, 4112)]      // 2 * 2056
        [TestCase(5, 160170)]    // 2 * 80085
        [TestCase(6, 246913578)] // 2 * 123456789
        [TestCase(7, 1440)]      // 2 * 720
        [TestCase(8, 360)]       // -2 * -180
        [TestCase(9, 720)]       // -2 * -360
        public void GenMagicNum_WithValidInput_ReturnsExpectedResultParameterized(double input, double expectedValue)
        {
            string filePath = "MagicNumbers.txt";
            IFileReader fileReader = _mockFileReader.Object;

            double result = _calculator.GenMagicNum(input, fileReader, filePath);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GenMagicNum_WithInputOutOfRangeHigh_ReturnsZero()
        {
            double input = 100;
            string filePath = "MagicNumbers.txt";
            IFileReader fileReader = _mockFileReader.Object;

            double result = _calculator.GenMagicNum(input, fileReader, filePath);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GenMagicNum_WithNegativeInput_ReturnsZero()
        {
            double input = -1;
            string filePath = "MagicNumbers.txt";
            IFileReader fileReader = _mockFileReader.Object;

            double result = _calculator.GenMagicNum(input, fileReader, filePath);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GenMagicNum_WithNonIntegerInput_ThrowsArgumentException()
        {
            double input = 1.5;
            string filePath = "MagicNumbers.txt";
            IFileReader fileReader = _mockFileReader.Object;

            Assert.Throws<ArgumentException>(() =>
                _calculator.GenMagicNum(input, fileReader, filePath));
        }

        [Test]
        public void GenMagicNum_WithMissingFile_ThrowsFileNotFoundException()
        {
            double input = 1;
            string filePath = "NonExistentFile.txt";
            IFileReader fileReader = _mockFileReader.Object;

            Assert.Throws<FileNotFoundException>(() =>
                _calculator.GenMagicNum(input, fileReader, filePath));
        }
    }
}
