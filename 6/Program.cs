Guard guard = new()
{
    Direction = Direction.Up,
    Position = (0, 0),
    Visited = [],
};

StreamReader sr = new("../../../input.txt");

HashSet<(int x, int y)> obstacles = [];

int row = 0;
int width = 0;
while (!sr.EndOfStream)
{
    var line = sr.ReadLine();
    width = Math.Max(width, line!.Length);
    for (var col = 0; col < line!.Length; col++)
    {
        if (line[col] == '#')
        {
            obstacles.Add((col, row));
        }
        else if (line[col] == '^')
        {
            Console.WriteLine($"Guard found at {col}, {row}");
            guard.Position = (col, row);
            guard.Visited.Add(guard.Position);
        }
    }
    row++;
}
int height = row;

while (!WalkStraight(ref guard))
{
    Console.WriteLine($"Guard walked to {guard.Position}");

    switch (guard.Direction)
    {
        case Direction.Up:
            guard.Direction = Direction.Right;
            break;
        case Direction.Right:
            guard.Direction = Direction.Down;
            break;
        case Direction.Down:
            guard.Direction = Direction.Left;
            break;
        case Direction.Left:
            guard.Direction = Direction.Up;
            break;
    }
    Console.WriteLine($"Guard turned to {guard.Direction}");
}

Console.WriteLine($"The guard has visited {guard.Visited.Count} areas");

bool WalkStraight(ref Guard guard)
{
    (int x, int y) checkPosition = guard.Position;
    while (!obstacles.Contains(checkPosition))
    {
        guard.Position = checkPosition;

        if (
            guard.Position.x == 0
            || guard.Position.x == width
            || guard.Position.y == 0
            || guard.Position.y == height
        )
        {
            return true;
        }
        switch (guard.Direction)
        {
            case Direction.Up:
                checkPosition = (guard.Position.x, guard.Position.y - 1);
                break;
            case Direction.Right:
                checkPosition = (guard.Position.x + 1, guard.Position.y);
                break;
            case Direction.Down:
                checkPosition = (guard.Position.x, guard.Position.y + 1);
                break;
            case Direction.Left:
                checkPosition = (guard.Position.x - 1, guard.Position.y);
                break;
        }
        guard.Visited.Add(guard.Position);
    }
    return false;
}

struct Guard
{
    public Direction Direction { get; set; }
    public (int x, int y) Position { get; set; }
    public HashSet<(int x, int y)> Visited { get; set; }
}

enum Direction
{
    Up,
    Right,
    Down,
    Left,
}
