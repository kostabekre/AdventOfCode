using System.Collections;
using Solutions.Logging;

namespace Solutions.Day3;

public class Day3Lobby
{
    private readonly ILogger _logger;

    public Day3Lobby(ILogger logger)
    {
        _logger = logger;
    }

    public int GetSumOfMost2PowerfulBatteriesInBanks(IList<string> banks)
    {
        int sum = 0;

        foreach (var bank in banks)
        {
            sum += FindMostPowerfulBatteries(bank);
        }

        return sum;
    }

    private int FindMostPowerfulBatteries(string bank)
    {
        var maxKnownLeftBattery = (int)char.GetNumericValue(bank[0]);
        var maxKnownPair = 0;

        for (int l = 0; l < bank.Length - 1; l++)
        {
            var leftBattery = (int)char.GetNumericValue(bank[l]);

            _logger.LogInfo($"Left: {leftBattery}, max: {maxKnownLeftBattery}");

            if (leftBattery < maxKnownLeftBattery)
            {
                continue;
            }

            if (leftBattery > maxKnownLeftBattery)
            {
                maxKnownLeftBattery = leftBattery;
            }

            var r = l + 1;

            _logger.LogInfo($"Left: {l}, right: {r}");

            var maxKnownRightBattery = (int)char.GetNumericValue(bank[r]);

            while (r < bank.Length)
            {
                var rightBattery = (int)char.GetNumericValue(bank[r]);

                if (rightBattery < maxKnownRightBattery)
                {
                    r++;
                    continue;
                }

                var str = new string([bank[l], bank[r]]);
                _logger.LogInfo($"Pair as str: {str}");
                var pair = int.Parse(str);

                maxKnownPair = pair > maxKnownPair ? pair : maxKnownPair;

                r++;
            }
        }

        return maxKnownPair;
    }
}
