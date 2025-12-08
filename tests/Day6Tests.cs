using Day_6___Trash_Compactor;

namespace AdventOfCode2025.Tests;

public class Day6Tests
{
    private readonly List<string> _testData =
    [
        "123 328  51 64 ",
        " 45 64  387 23 ",
        "  6 98  215 314",
        "*   +   *   +  "
    ];
    
    private readonly List<Day6.MathProblem> _testDataMathProblems =
    [
        new([123, 45, 6],"*"),
        new([328, 64, 98],"+"),
        new([51, 387, 215], "*"),
        new([64, 23, 314], "+")
    ];

    [Fact]
    public void ParseInput_ReturnsExpectedMathProblems()
    {
        // Arrange
        var expectedResult = _testDataMathProblems;
        
        // Act
        var result = Day6.ParseInput(_testData);
        
        // Assert
        Assert.Equivalent(expectedResult, result, strict: true);
    }
    
    [Fact]
    public void GrandTotalOfProblems_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 4277556;
        
        // Act
        var result = Day6.GrandTotalOfProblems(_testDataMathProblems);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
}