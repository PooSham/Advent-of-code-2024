using System.Numerics;

StreamReader sr = new("./input.txt");

BigInteger sum = 0;

// Part2 doesn't really work yet, but I think it's close
const bool part2 = false;

while (!sr.EndOfStream)
{
    var line = sr.ReadLine();
    var splitLine = line!.Split(": ");
    var testValue = BigInteger.Parse(splitLine[0]);
    var numbers = splitLine[1].Split(" ").Select(BigInteger.Parse);

    var first = numbers.First();
    var rest = numbers.Skip(1);

    if (TestNumbers(testValue, first, rest) || TryCombine(testValue, 0, first, rest))
    {
        sum += testValue;
    }
}

Console.WriteLine(sum);

static bool TestNumbers(
    BigInteger testValue,
    BigInteger aggregatedValue,
    IEnumerable<BigInteger> numbers
)
{
    if (!numbers.Any())
    {
        return testValue == aggregatedValue;
    }
    var first = numbers.First();
    var rest = numbers.Skip(1);

    if (
        TestNumbers(testValue, aggregatedValue + first, rest)
        || TestNumbers(testValue, aggregatedValue * first, rest)
    )
    {
        return true;
    }
    else if (part2)
    {
        return TryCombine(testValue, aggregatedValue, first, rest);
    }
    else
    {
        return false;
    }
}

static bool TryCombine(
    BigInteger testValue,
    BigInteger aggregatedValue,
    BigInteger first,
    IEnumerable<BigInteger> rest,
    int depth = 0
)
{
    // Console.WriteLine($"{testValue}: {first} % {string.Join(" ", rest)} ({depth})");
    if (!rest.Any())
    {
        return aggregatedValue == testValue;
    }

    var second = rest.First();
    var combined = BigInteger.Parse($"{first}{second}");
    var restRest = rest.Skip(1);

    return TryCombine(testValue, aggregatedValue, combined, restRest, depth + 1)
        || TestNumbers(testValue, aggregatedValue + combined, restRest)
        || TestNumbers(testValue, aggregatedValue * combined, restRest);
}
