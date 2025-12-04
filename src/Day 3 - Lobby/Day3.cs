namespace Day_3___Lobby;

public static class Day3
{
    public static int FindMaximumJoltage(List<string> batteryBanks)
    {
        var sumOfJoltage = 0;

        foreach (var bank in batteryBanks)
        {
            Console.WriteLine($"Checking bank: {bank}");
            
            var joltage = BankJoltage(bank);
            
            Console.WriteLine($"> Bank joltage: {joltage}\n");
            sumOfJoltage += joltage;
        }
        
        return sumOfJoltage;
    }

    public static int BankJoltage(string bank)
    {
        var bankLen = bank.Length;
        var position = 0;
        List<int> batteries = [];
        
        for (var battery = 0; battery < 2; battery++)
        {
            var biggestBattery = 0;

            var chunk = bank.Substring(position, (bankLen - 1) - position + battery);
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
    
}