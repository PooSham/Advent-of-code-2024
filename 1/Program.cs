// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic.FileIO;


/***************************** PART 1 *********************************/ 
StreamReader sr = new("./input.txt");

List<string> input1 = [];
List<string> input2 = [];

using (TextFieldParser parser = new (sr))
{
    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters("   ");
    while (!parser.EndOfData)
    {
        //Process row
        string[]? fields = parser.ReadFields();
        input1.Add(fields![0]);
        input2.Add(fields![1]);
    }
}

input1.Sort();
input2.Sort();

var sum = 0;

for(var i = 0; i < input1.Count; i++) {
    var diff = Math.Abs(int.Parse(input1[i]) - int.Parse(input2[i]));
    sum += diff;
}

Console.WriteLine(sum);

/***************************** PART 2 *********************************/ 
var dict = input2.GroupBy(int.Parse).ToDictionary(x => x.Key, x => x.Count());
var sum2 = 0;
for (var i = 0; i < input1.Count; i++) {
    var num = int.Parse(input1[i]);
    dict.TryGetValue(num, out int occurences);
    sum2 += num * occurences;
}

Console.WriteLine(sum2);