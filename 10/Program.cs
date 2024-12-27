var sr = new StreamReader("./input.txt");
var map = sr.ReadToEnd().Split("\n");

var score = 0;
var rating = 0;
for (int y = 0; y < map.Length; y++)
{
    for (int x = 0; x < map[y].Length; x++)
    {
        if (map[y][x] == '0')
        {
            HashSet<(int x, int y)> scoreHolder = [];
            rating += FindTrails(x, y, ref scoreHolder);
            score += scoreHolder.Count;
        }
    }
}

Console.WriteLine(score);
Console.WriteLine(rating);

int FindTrails(int x, int y, ref HashSet<(int x, int y)> scoreHolder)
{
    var pos = map[y][x];
    if (pos == '9')
    {
        scoreHolder.Add((x, y));
        return 1;
    }
    char? up = y > 0 ? map[y - 1][x] : null;
    char? right = x < map[y].Length - 1 ? map[y][x + 1] : null;
    char? down = y < map.Length - 1 ? map[y + 1][x] : null;
    char? left = x > 0 ? map[y][x - 1] : null;

    int sum = 0;
    if (up is not null && up == pos + 1)
    {
        sum += FindTrails(x, y - 1, ref scoreHolder);
    }
    if (right is not null && right == pos + 1)
    {
        sum += FindTrails(x + 1, y, ref scoreHolder);
    }
    if (down is not null && down == pos + 1)
    {
        sum += FindTrails(x, y + 1, ref scoreHolder);
    }
    if (left is not null && left == pos + 1)
    {
        sum += FindTrails(x - 1, y, ref scoreHolder);
    }
    return sum;
}
