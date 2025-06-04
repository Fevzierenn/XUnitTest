using System;
using UnitTest;
using Xunit;

namespace QuadraticUnitTestProject
{
    public class Tests
    {
        
        QuadraticEquation quadratic = new QuadraticEquation();

        [Theory]
        [InlineData(1, 0, 1)] // b² - 4ac = -4 → No real root
        [InlineData(2, 1, 2)] // Discriminant < 0
        public void DiscriminantLessThanZero(double a, double b, double c)
        {
            // Act
            var result = quadratic.Solve(a, b, c);

            // Assert
            Assert.Empty(result.Roots);
            Assert.Equal("No real roots.", result.Message);
        }
        
        
        
        [Theory]
        [InlineData(1, -2, 1, 1.0)] // b² - 4ac = 0 → one real root x = 1
        [InlineData(4, 4, 1, -0.5)] // D = 0
        public void DiscriminantEqualsZero(double a, double b, double c, double expected)
        {
            // Act
            var result = quadratic.Solve(a, b, c);

            // Assert
            Assert.Single(result.Roots);
            Assert.Equal(expected, result.Roots[0], precision: 5);
            Assert.Equal("One real root.", result.Message);
        }

        [Theory]
        [InlineData(1, -3, 2, 2.0, 1.0)] // x² -3x + 2 = 0 → roots: 2,1
        [InlineData(1, 0, -4, 2.0, -2.0)] // x² -4 = 0 → roots: ±2
        public void DiscriminantGreaterThanZero(double a, double b, double c, double expected1, double expected2)
        {
            
            var result = quadratic.Solve(a, b, c);

            // Assert
            Assert.Equal(2, result.Roots.Length);
            Assert.Contains(expected1, result.Roots);
            Assert.Contains(expected2, result.Roots);
            Assert.Equal("Two real roots.", result.Message);
        }

        [Fact]
        public void Solve_AIsZero_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => quadratic.Solve(0, 2, 3));
            Assert.Equal("a must not be 0 in a quadratic equation.", ex.Message);
            
        }

    }
}