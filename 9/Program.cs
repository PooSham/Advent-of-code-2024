using System.Numerics;
using System.Text;

var sr = new StreamReader("./input.txt");
char EMPTY = char.MaxValue;
var sb = new StringBuilder();
char id = (char)0;
while (!sr.EndOfStream)
{
    sb.Append(id, GetRepeatDigit());

    var repeat = GetRepeatDigit();
    if (repeat == -1)
    {
        break;
    }
    sb.Append(EMPTY, repeat);
    id++;
}

int i = 0;
int j = sb.Length - 1;

while (true)
{
    while (sb[i] != EMPTY && i < j)
    {
        i++;
    }
    while (sb[j] == EMPTY && i < j)
    {
        sb.Remove(j, 1);
        j--;
    }
    if (i >= j)
    {
        break;
    }
    sb[i] = sb[j];
    sb.Remove(j, 1);
    j--;
}

BigInteger sum = 0;
for (i = 0; i < sb.Length; i++)
{
    if (sb[i] < 0)
    {
        Console.WriteLine(sb[i]);
    }
    sum += i * sb[i];
}

Console.WriteLine(sum);

int GetRepeatDigit()
{
    var ch = (char)sr.Read();
    var repeat = char.GetNumericValue(ch);
    return double.ConvertToInteger<int>(repeat);
}
