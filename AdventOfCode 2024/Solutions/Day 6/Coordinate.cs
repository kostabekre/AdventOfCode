namespace Solutions.Day_6;

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