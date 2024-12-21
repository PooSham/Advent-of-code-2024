using System.Text.RegularExpressions;

StreamReader sr = new("./input.txt");

var wholeInput = sr.ReadToEnd();

/***************************** PART 1 *********************************/
static int Part1(string input)
{
    var regex = new Regex(@"mul\((\d+),(\d+)\)");

    var sum = 0;

    foreach (Match match in regex.Matches(input))
    {
        var lhs = match.Groups.Values.ElementAt(1).Value;
        var rhs = match.Groups.Values.ElementAt(2).Value;
        sum += int.Parse(lhs) * int.Parse(rhs);
    }
    return sum;
}
Console.WriteLine(Part1(wholeInput));

/***************************** PART 2 *********************************/

var inputSplitOnDont = wholeInput.Split("don't");

// First part is special because it starts enabled
var sum = Part1(inputSplitOnDont.First());

// After each "don't", we have to find a "do"
foreach (var inputPart in inputSplitOnDont.Skip(1))
{
    var inputSplitOnDo = inputPart.Split("do");
    // After the "do", we're good to go.
    var inputPartToDo = string.Join("", inputSplitOnDo.Skip(1));

    sum += Part1(inputPartToDo);
}
Console.WriteLine(sum);
