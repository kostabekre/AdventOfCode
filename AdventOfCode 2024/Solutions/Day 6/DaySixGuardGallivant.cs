namespace Solutions.Day_6;

public enum Directions
{
    Up,
    Right,
    Down, 
    Left
}

public struct Coordinate
{
    public int X { get; }
    public int Y { get; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}";
    }
    public bool Equals(Coordinate other)
    {
        return X == other.X && Y == other.Y;
    }
    public override bool Equals(object? obj)
    {
        var other = obj is Coordinate ? (Coordinate)obj : default;

        if (obj is not Coordinate)
        {
            return false;
        }

        return Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
public class DaySixGuardGallivant : ISolution
{
    public static char GuardCharacter = '^';
    private readonly char[][] _map;
    private readonly Coordinate _startPosition;

    public DaySixGuardGallivant(DaySixArgs args)
    {
        _map = args.Map;
        _startPosition = args.StartPosition;
    }
    
    public int SolveFirstPart()
    {
        var currentPosition = _startPosition;

        var direction = Directions.Up;
        var visited = new HashSet<Coordinate>{currentPosition};
        
        while (true)
        {
            var nextPosition = GetNextPosition(currentPosition, direction);
            var isInside = isInsideTerritory(nextPosition, direction);
            if (isInside == false)
            {
                break;
            }
            var nextCharacter = GetCharacter(nextPosition);
            if (nextCharacter == '#')
            {
                direction = GetNextDirection(direction);
            }
            else
            {
                visited.Add(currentPosition);
                currentPosition = nextPosition;
            }
        }

        // add one, because last position wasn't added.
        return visited.Count + 1;
    }

    private Coordinate GetNextPosition(Coordinate coordinate, Directions direction)
    {
        switch (direction)
        {
            case Directions.Up:
                return new Coordinate(  coordinate.X ,coordinate.Y - 1);
            case Directions.Right:
                return new Coordinate( coordinate.X + 1 ,coordinate.Y );
            case Directions.Down:
                return new Coordinate(  coordinate.X,coordinate.Y + 1);
            case Directions.Left:
                return new Coordinate( coordinate.X - 1 ,coordinate.Y );
            default:
                throw new ArgumentException("Unknown direction");
        }
    }
    private Directions GetNextDirection(Directions currentDirection)
    {
        switch (currentDirection)
        {
            case Directions.Right:
                return Directions.Down;
            case Directions.Down:
                return Directions.Left;
            case Directions.Left:
                return Directions.Up;
            case Directions.Up:
                return Directions.Right;
            default:
                throw new ArgumentException("Unknown direction");
        }
    }
    private bool isInsideTerritory(Coordinate nextPosition, Directions direction)
    {
        switch (direction)
        {
            case Directions.Up:
                return _map.Length + nextPosition.Y >= _map.Length;
            case Directions.Right:
                return _map[0].Length - (nextPosition.X + 1) >= 0;
            case Directions.Down:
                return _map.Length - (nextPosition.Y + 1) >= 0;
            case Directions.Left:
                return _map[0].Length + nextPosition.X >= _map.Length;
            default:
                throw new ArgumentException("Unknown direction");
        }
    }
    private char GetCharacter(Coordinate nextPosition)
    {
        return _map[nextPosition.Y][nextPosition.X];
    }

    public int SolveSecondPart()
    {
        throw new NotImplementedException();
    }
}