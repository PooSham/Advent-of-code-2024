using System.Numerics;

var stonesMap = new Dictionary<string, BigInteger>
{
    { "20", 1 },
    { "82084", 1 },
    { "1650", 1 },
    { "3", 1 },
    { "346355", 1 },
    { "363", 1 },
    { "7975858", 1 },
    { "0", 1 },
};

for (int i = 0; i < 1000; i++)
{
    Dictionary<string, BigInteger> stonesAfterBlink = [];
    foreach (var stoneKV in stonesMap)
    {
        var stoneInt = BigInteger.Parse(stoneKV.Key);
        if (stoneInt == 0)
        {
            AddToDictionary(stonesAfterBlink, "1", stoneKV.Value);
        }
        else if (stoneKV.Key.ToString().Length % 2 == 0)
        {
            AddToDictionary(
                stonesAfterBlink,
                BigInteger
                    .Parse(string.Concat(stoneKV.Key.Take(stoneKV.Key.Length / 2)))
                    .ToString(),
                stoneKV.Value
            );
            AddToDictionary(
                stonesAfterBlink,
                BigInteger
                    .Parse(string.Concat(stoneKV.Key.Skip(stoneKV.Key.Length / 2)))
                    .ToString(),
                stoneKV.Value
            );
        }
        else
        {
            AddToDictionary(stonesAfterBlink, (stoneInt * 2024).ToString(), stoneKV.Value);
        }
    }
    stonesMap = stonesAfterBlink;
}

BigInteger sum = 0;
foreach (var stoneKV in stonesMap)
{
    sum += stoneKV.Value;
}

Console.WriteLine(sum);

static void AddToDictionary(Dictionary<string, BigInteger> dict, string key, BigInteger amount)
{
    dict.TryAdd(key, 0);
    dict[key] += amount;
}
