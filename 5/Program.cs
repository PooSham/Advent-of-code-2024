StreamReader sr = new("../../../input.txt");

var input = sr.ReadToEnd();
var splitInput = input.Split("\n\n");

var rules = splitInput[0].Split("\n");
var updates = splitInput[1].Split("\n");

var part1 = 0;

foreach (var update in updates)
{
    var pages = update.Split(",");
    if (pages.Length == 1)
    {
        continue;
    }
    string[] correctedPages = [.. pages];
    var errors = false;

    foreach (var rule in rules)
    {
        var ruleSplit = rule.Split('|');
        var ruleBefore = ruleSplit[0];
        var ruleAfter = ruleSplit[1];

        var indexBefore = Array.IndexOf(pages, ruleBefore);
        var indexAfter = Array.IndexOf(pages, ruleAfter);

        if (indexBefore != -1 && indexAfter != -1 && indexBefore > indexAfter)
        {
            errors = true;
            break;
        }
    }

    if (!errors)
    {
        var middle = pages[pages.Length / 2];
        part1 += int.Parse(middle);
    }
}

Console.WriteLine(part1);
