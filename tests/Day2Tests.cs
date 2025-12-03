using Day_2___Gift_Shop;

namespace AdventOfCode2025.Tests;

public class Day2Tests
{
    [Fact]
    public void ParseInput_ReturnsExpectedRanges()
    {
        // Arrange
        const string input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        var expected = new List<Day2.Range>
        {
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
        };
        
        // Act
        var result = Day2.ParseInput(input);
        
        // Assert
        Assert.Equal(expected, result);
    }
}