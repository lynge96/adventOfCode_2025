using Day_5___Cafeteria;

namespace AdventOfCode2025.Tests;

public class Day5Tests
{
    private readonly List<string> _testData =
    [
        "3-5",
        "10-14",
        "16-20",
        "12-18",
        "",
        "1",
        "5",
        "8",
        "11",
        "17",
        "32"
    ];

    private readonly List<Day5.Ranges> _testRanges =
    [
        new(3, 5),
        new(10, 14),
        new(16, 20),
        new(12, 18)
    ];
    
    [Fact]
    public void ParseInput_ReturnsExpectedRangesAndIds()
    {
        // Arrange
        var expectedRanges = new List<Day5.Ranges>
        {
            new(3, 5),
            new(10, 14),
            new(16, 20),
            new(12, 18)
        };

        var expectedIds = new List<Day5.ProductId>
        {
            new(1),
            new(5),
            new(8),
            new(11),
            new(17),
            new(32)
        };

        // Act
        var (rangeResult, idsResult) = Day5.ParseInput(_testData);

        // Assert
        Assert.Equal(expectedRanges, rangeResult);
        Assert.Equal(expectedIds, idsResult);
    }

    [Fact]
    public void CountAvailableIngredients_CorrectOutput()
    {
        // Arrange
        var expectedSum = 3;
        
        // Act
        var result = Day5.CountAvailableIngredients(_testData);
        
        // Assert
        Assert.Equal(expectedSum, result);
    }

    [Fact]
    public void TotalAvailableIngredients_CorrectOutput()
    {
        // Arrange
        var expectedSum = 14;
        
        // Act
        var result = Day5.TotalAvailableIngredients(_testData);
        
        // Assert
        Assert.Equal(expectedSum, result);
    }

    [Fact]
    public void SortAndMergeRanges()
    {
        // Arrange
        List<Day5.Ranges> expectedRanges = [new(3, 5), new(10, 20)];
        
        // Act
        var result = Day5.SortAndMergeRanges(_testRanges);
        
        // Assert
        Assert.Equal(expectedRanges, result);
    }
}