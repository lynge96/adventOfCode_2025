namespace Day_3___Lobby;

public static class Day3
{
    public static int FindMaximumJoltageForTwoBatteries(List<string> batteryBanks)
    {
        var sumOfJoltage = 0;

        foreach (var bank in batteryBanks)
        {
            Console.WriteLine($"Checking bank: {bank}");
            
            var joltage = BankJoltageForTwoBatteries(bank);
            
            Console.WriteLine($"> Bank joltage: {joltage}\n");
            sumOfJoltage += joltage;
        }
        
        return sumOfJoltage;
    }

    public static int BankJoltageForTwoBatteries(string bank)
    {
        var bankLen = bank.Length;
        var position = 0;
        List<int> batteries = [];
        
        for (var battery = 0; battery < 2; battery++)
        {
            var biggestBattery = 0;

            var searchLength = (bankLen - 1) - position + battery;
            var chunk = bank.Substring(position, searchLength);
            var chunkLen = chunk.Length;

            for (var p = 0; p < chunkLen; p++)
            {
                var currentBattery = int.Parse(chunk.Substring(p, 1));

                if (currentBattery == 9)
                {
                    biggestBattery = currentBattery;
                    position = p + 1;
                    break;
                }
                if (currentBattery > biggestBattery)
                {
                    biggestBattery = currentBattery;
                    position = p + 1;
                }
            }
            
            batteries.Add(biggestBattery);
        }

        var combinedBatteries = int.Parse(string.Concat(batteries));
        return combinedBatteries;
    }

    public static long FindMaximumJoltageForTwelveBatteries(List<string> batteryBanks)
    {
        long sumOfJoltage = 0;

        foreach (var bank in batteryBanks)
        {
            Console.WriteLine($"Checking bank: {bank}");
            
            var joltage = BankJoltageForTwelveBatteries(bank);
            
            Console.WriteLine($"> Bank joltage: {joltage}\n");
            sumOfJoltage += joltage;
        }
        
        return sumOfJoltage;
    }
    
    public static long BankJoltageForTwelveBatteries(string bank)
    {
        var bankLen = bank.Length; // 15
        var position = 0;
        List<long> batteries = [];
        const int batteryAmount = 12;
        
        for (var battery = 1; battery <= batteryAmount; battery++)
        {
            var biggestBattery = 0;
            var batteryIndex = 0;
            
            var digitsLeft = bankLen - position;
            var searchLength = digitsLeft - batteryAmount + battery ;
            
            var chunk = bank.Substring(position, searchLength);
            var chunkLen = chunk.Length;

            for (var p = 0; p < chunkLen; p++)
            {
                var currentBattery = int.Parse(chunk.Substring(p, 1));

                if (currentBattery == 9)
                {
                    biggestBattery = currentBattery;
                    batteryIndex = p;
                    break;
                }
                if (currentBattery > biggestBattery)
                {
                    biggestBattery = currentBattery;
                    batteryIndex = p;
                }
            }

            position += batteryIndex + 1;
            
            batteries.Add(biggestBattery);
            if (batteries.Count == batteryAmount)
            {
                break;
            }
        }
        
        var combinedBatteries = long.Parse(string.Concat(batteries));
        return combinedBatteries;
    }
    
}