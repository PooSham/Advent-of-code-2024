StreamReader sr = new("./input.txt");

string[] lines = [];

while (!sr.EndOfStream)
{
    var line = sr.ReadLine();
    lines = lines.Append(line).ToArray()!;
}

var part1 = CountXMAS(GetHorizontalRightWords(lines));
part1 += CountXMAS(GetHorizontalLeftWords(lines));
part1 += CountXMAS(GetVerticalDownWords(lines));
part1 += CountXMAS(GetVerticalUpWords(lines));
part1 += CountXMAS(GetDiagonalDownRightWords(lines));
part1 += CountXMAS(GetDiagonalDownLeftWords(lines));
part1 += CountXMAS(GetDiagonalUpRightWords(lines));
part1 += CountXMAS(GetDiagonalUpLeftWords(lines));

Console.WriteLine(part1);

static int CountXMAS(string[] input)
{
    var res = input.Count(x => x == "XMAS");
    Console.WriteLine(res);
    return res;
}

static string[] GetHorizontalRightWords(string[] lines)
{
    string[] fourLetterWords = [];
    foreach (var line in lines)
    {
        for (var i = 0; i < line.Length - 3; i++)
        {
            fourLetterWords = [.. fourLetterWords, line.Substring(i, 4)];
        }
    }
    return fourLetterWords;
}

static string[] GetHorizontalLeftWords(string[] lines)
{
    return GetHorizontalRightWords(ReverseLines(lines));
}

static string[] GetVerticalDownWords(string[] lines)
{
    string[] fourLetterWords = [];
    for (var i = 0; i < lines[0].Length; i++)
    {
        for (var j = 0; j < lines.Length - 3; j++)
        {
            char[] columnWord = [];
            for (var k = 0; k < 4; k++)
            {
                columnWord = [.. columnWord, lines[j + k][i]];
            }
            fourLetterWords = [.. fourLetterWords, new string(columnWord)];
        }
    }
    return fourLetterWords;
}

static string[] GetVerticalUpWords(string[] lines)
{
    return GetVerticalDownWords(ReverseColumns(lines));
}

static string[] GetDiagonalDownRightWords(string[] lines)
{
    string[] fourLetterWords = [];
    for (var i = 0; i < lines.Length - 3; i++)
    {
        for (var j = 0; j < lines[0].Length - 3; j++)
        {
            char[] diagonalWord = [];
            for (var k = 0; k < 4; k++)
            {
                diagonalWord = [.. diagonalWord, lines[i + k][j + k]];
            }
            fourLetterWords = [.. fourLetterWords, new string(diagonalWord)];
        }
    }
    return fourLetterWords;
}

static string[] GetDiagonalDownLeftWords(string[] lines)
{
    return GetDiagonalDownRightWords(ReverseLines(lines));
}

static string[] GetDiagonalUpRightWords(string[] lines)
{
    return GetDiagonalDownRightWords(ReverseColumns(lines));
}

static string[] GetDiagonalUpLeftWords(string[] lines)
{
    return GetDiagonalDownRightWords(ReverseColumns(ReverseLines(lines)));
}

static string[] ReverseLines(string[] lines)
{
    string[] reversedLines = [];
    foreach (var line in lines)
    {
        reversedLines = [.. reversedLines, new string(line.Reverse().ToArray())];
    }
    return reversedLines;
}

static string[] ReverseColumns(string[] lines)
{
    return lines.Reverse().ToArray();
}

var part2 = 0;

for (var i = 1; i < lines.Length - 1; i++)
{
    for (var j = 1; j < lines[i].Length - 1; j++)
    {
        if (lines[i][j] == 'A')
        {
            var downSlopeOk =
                lines[i - 1][j - 1] == 'M' && lines[i + 1][j + 1] == 'S'
                || lines[i - 1][j - 1] == 'S' && lines[i + 1][j + 1] == 'M';

            var upSlopeOk =
                lines[i - 1][j + 1] == 'M' && lines[i + 1][j - 1] == 'S'
                || lines[i - 1][j + 1] == 'S' && lines[i + 1][j - 1] == 'M';

            if (downSlopeOk && upSlopeOk)
            {
                part2++;
            }
        }
    }
}
Console.WriteLine(part2);
