using Microsoft.VisualBasic.FileIO;

var safeReports = 0;

StreamReader sr = new("./input.txt");
var line = sr.ReadLine();

while (line != null)
{
    var report = line.Split(' ').Select(int.Parse);

    if (IsReportSafe(report))
    {
        safeReports++;
    }
    else if (true) // change to false for part 1
    {
        for (int i = 0; i < report.Count(); i++)
        {
            if (IsReportSafe(report.WithoutElementAt(i)))
            {
                safeReports++;
                break;
            }
        }

    }

    line = sr.ReadLine();
}

Console.WriteLine(safeReports);

static bool IsReportSafe(IEnumerable<int> report)
{
    var (isIncreasing, isDecreasing) = (true, true);

    for (int i = 1; i < report.Count(); i++)
    {
        var prevLevel = report.ElementAt(i - 1);
        var currLevel = report.ElementAt(i);
        var diff = currLevel - prevLevel;

        if (diff > 3 || diff < 1)
        {
            isIncreasing = false;
        }
        if (diff < -3 || diff > -1)
        {
            isDecreasing = false;
        }
    }

    return isIncreasing || isDecreasing;
}

public static class MyExtensions
{
    public static IEnumerable<T> WithoutElementAt<T>(this IEnumerable<T> self, int index)
    {
        List<T> newList = [];
        for (int i = 0; i < self.Count(); i++)
        {
            if (index != i)
            {
                newList.Add(self.ElementAt(i));
            }
        }
        return newList.AsEnumerable();
    }

}

