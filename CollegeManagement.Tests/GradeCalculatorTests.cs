using CollegeManagement.Services;

namespace CollegeManagement.Tests
{
    public class GradeCalculatorTests
    {
        [Fact]
        public void GetGrade_WhenMarksAre85_ShouldReturnDistinction()
        {
            var calculator = new GradeCalculator();

            var result = calculator.GetGrade(85);

            Assert.Equal("Distinction", result);
        }

        [Fact]
        public void GetGrade_WhenMarksAre65_ShouldReturnFirstDivision()
        {
            var calculator = new GradeCalculator();

            var result = calculator.GetGrade(65);

            Assert.Equal("First Division", result);
        }

        [Fact]
        public void GetGrade_WhenMarksAre45_ShouldReturnPass()
        {
            var calculator = new GradeCalculator();

            var result = calculator.GetGrade(45);

            Assert.Equal("Pass", result);
        }

        [Fact]
        public void GetGrade_WhenMarksAre30_ShouldReturnFail()
        {
            var calculator = new GradeCalculator();

            var result = calculator.GetGrade(30);

            Assert.Equal("Fail", result);
        }

        [Fact]
        public void GetGrade_WhenMarksAreInvalid_ShouldThrowException()
        {
            var calculator = new GradeCalculator();

            Assert.Throws<ArgumentException>(() =>
                calculator.GetGrade(120)
            );
        }
    }
}
