using Day_2___Gift_Shop;

namespace AdventOfCode2025.Tests;

public class Day2Tests
{
    private readonly List<Day2.Range> _testRange =
    [
        new(11, 22),
        new(95, 115),
        new(998, 1012),
        new(1188511880, 1188511890),
        new(222220, 222224),
        new(1698522, 1698528),
        new(446443, 446449),
        new(38593856, 38593862),
        new(565653, 565659),
        new(824824821, 824824827),
        new(2121212118, 2121212124)
    ];
    
    [Fact]
    public void ParseInput_ReturnsExpectedRanges()
    {
        // Arrange
        const string input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        
        // Act
        var result = Day2.ParseInput(input);
        
        // Assert
        Assert.Equal(_testRange, result);
    }

    [Fact]
    public void FindInvalidProductIds_ReturnsExpectedSum()
    {
        // Arrange
        var expectedSum = 1227775554;
        
        // Act
        var result = Day2.FindInvalidProductIds(_testRange);

        // Assert
        Assert.Equal(expectedSum, result);
    }
    
    [Theory]
    [InlineData(11, 1, 1)]
    [InlineData(22, 2, 2)]
    [InlineData(99, 9, 9)]
    [InlineData(1010, 10, 10)]
    [InlineData(1188511885, 11885, 11885)]
    [InlineData(222222, 222, 222)]
    [InlineData(446446, 446, 446)]
    [InlineData(38593859, 3859, 3859)]
    public void SplitNumber_ReturnsExpectedNumbers(
        long input,
        long expectedFirstNumber,
        long expectedSecondNumber)
    {
        // Act
        var (firstNumber, secondNumber) = Day2.SplitNumber(input);

        // Assert
        Assert.Equal(expectedFirstNumber, firstNumber);
        Assert.Equal(expectedSecondNumber, secondNumber);
    }
}