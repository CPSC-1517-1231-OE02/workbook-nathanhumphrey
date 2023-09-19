using FluentAssertions;
using Utils;

namespace UtilitiesTestProject
{
    public class UtilitiesTest
    {

        [Theory]
        [InlineData(1)]
        [InlineData(1.0D)]
        [InlineData("1.0")]

        public void Utilities_IsPositive_ReturnsTrueForPositive(object value)
        {
            bool actual;

            if (value.GetType() == typeof(int))
            {
                actual = Utilities.IsPositive((int)value);
            }
            else if (value.GetType() == typeof(double))
            {
                actual = Utilities.IsPositive((double)value);
            }
            else
            {
                actual = Utilities.IsPositive(Convert.ToDecimal(value));
            }

            actual.Should().BeTrue();
        }

        // DateOnly data generator
        public static IEnumerable<object[]> GenerateIsInTheFutureTestData()
        {
            // present
            yield return new object[] {
                DateOnly.FromDateTime(DateTime.Now), false
            };
            // past
            yield return new object[] {
                DateOnly.FromDateTime(DateTime.Now).AddDays(-1), false
            };
            // future
            yield return new object[] {
                DateOnly.FromDateTime(DateTime.Now).AddDays(1), true
            };
        }

        [Theory]
        [MemberData(nameof(GenerateIsInTheFutureTestData))] // present
        public void Utilities_IsInTheFuture_ReturnsTrueForFutureFalseOtherwise(DateOnly date, bool expected)
        {
            // Arrange
            bool actual;

            // Act
            actual = Utilities.IsInTheFuture(date);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsTrueForEmptyNullOrWhiteSpace(string value)
        {
            // Arrange
            bool actual;
            
            // Act
            actual = Utilities.IsNullEmptyOrWhiteSpace(value);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public void Utilities_IsNullEmptyOrWhiteSpace_ReturnsFalseForNonEmpty()
        {
            // Arrange
            bool actual;
            const string GOOD_STRING = "x";

            // Act
            actual = Utilities.IsNullEmptyOrWhiteSpace(GOOD_STRING);

            // Assert
            actual.Should().BeFalse();
        }
    }
}