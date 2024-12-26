var sr = new StreamReader("./input.txt");

var antennas = (List<Antenna>)[];

var rows = sr.ReadToEnd().Split("\n");
var noOfColumns = 0;
for (var row = 0; row < rows.Length; row++)
{
    var columns = rows[row].ToCharArray();
    noOfColumns = Math.Max(noOfColumns, columns.Length);
    for (var col = 0; col < columns.Length; col++)
    {
        if (columns[col] != '.')
        {
            antennas.Add(new Antenna { Name = columns[col], Position = new(col, row) });
        }
    }
}

var antennasLookup = antennas.ToLookup(x => x.Name, x => x.Position);
var antiNodes = (HashSet<Position>)[];

foreach (var antennaForFrequency in antennasLookup)
{
    for (int i = 0; i < antennaForFrequency.Count() - 1; i++)
    {
        var pos1 = antennaForFrequency.ElementAt(i);
        var x1 = pos1.X;
        var y1 = pos1.Y;

        for (int j = i + 1; j < antennaForFrequency.Count(); j++)
        {
            var pos2 = antennaForFrequency.ElementAt(j);
            var x2 = pos2.X;
            var y2 = pos2.Y;

            var diff = new Position(x1 - x2, y1 - y2);

            var antinode1 = new Position(x1 + diff.X, y1 + diff.Y);

            if (IsWithinLimits(antinode1))
            {
                antiNodes.Add(antinode1);
            }

            var antinode2 = new Position(x2 - diff.X, y2 - diff.Y);

            if (IsWithinLimits(antinode2))
            {
                antiNodes.Add(antinode2);
            }
        }
    }
}

Console.WriteLine(antiNodes.Count);

bool IsWithinLimits(Position position)
{
    return position.X >= 0
        && position.X < noOfColumns
        && position.Y >= 0
        && position.Y < rows.Length;
}

record struct Position(int X, int Y) { }

struct Antenna
{
    public char Name;
    public Position Position;
}
