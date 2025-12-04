using Day_3___Lobby;

namespace AdventOfCode2025.Tests;

public class Day3Tests
{
    private readonly List<string> _testData =
    [
        "987654321111111",
        "811111111111119",
        "234234234234278",
        "818181911112111"
    ];

    [Fact]
    public void FindMaximumJoltage_CorrectMaximumOutput()
    {
        // Arrange
        var expectedSum = 357;
        
        // Act
        var result = Day3.FindMaximumJoltageForTwoBatteries(_testData);
        
        // Assert
        Assert.Equal(expectedSum, result);
    }

    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void BankJoltageForTwoBatteries_CorrectOutput(string batteryBank, int expectedJoltage)
    {
        // Act
        var result = Day3.BankJoltageForTwoBatteries(batteryBank);
        
        // Assert
        Assert.Equal(expectedJoltage, result);
    }

    [Theory]
    [InlineData("987654321111111", 987654321111)]
    [InlineData("811111111111119", 811111111119)]
    [InlineData("234234234234278", 434234234278)]
    [InlineData("818181911112111", 888911112111)]
    public void BankJoltageForTwelveBatteries_CorrectOutput(string batteryBank, long expectedJoltage)
    {
        // Act
        var result = Day3.BankJoltageForTwelveBatteries(batteryBank);
        
        // Assert
        Assert.Equal(expectedJoltage, result);
    }
    
}