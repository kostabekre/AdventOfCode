namespace Solutions.Day1;

public class Day1SecretEntarance
{
    public int GetNumberOfStopsAtZero(IList<string> rotations)
    {
        var converted = ConvertRotations(rotations);

        var dial = 50;
        var result = 0;

        foreach (var rotation in converted)
        {
            dial = GetDial(dial, rotation);

            if (dial == 0)
            {
                result++;
            }
        }

        return result;
    }

    public int GetNumberOfAllRotations(IList<string> rotations)
    {
        var converted = ConvertRotations(rotations);

        var dial = 50;
        var result = 0;

        foreach (var rotation in converted)
        {
            dial = GetDial(dial, rotation, out var passedEdge);

            result += passedEdge;
        }

        return result;
    }

    private int GetDial(int currentDial, Rotation rotation)
    {
        int newDial = currentDial;
        var rotationsLeft = rotation.Number;

        while (rotationsLeft > 0)
        {
            rotationsLeft--;

            if (rotation.Direction == Direction.Right)
            {
                newDial++;
            }
            else
            {
                newDial--;
            }

            if (newDial == 100)
            {
                newDial = 0;
            }
            else if (newDial == -1)
            {
                newDial = 99;
            }
        }

        return newDial;
    }

    private int GetDial(int currentDial, Rotation rotation, out int passedEdge)
    {
        passedEdge = 0;

        int newDial = currentDial;
        var rotationsLeft = rotation.Number;

        while (rotationsLeft > 0)
        {
            if (newDial == 0)
            {
                passedEdge++;
            }

            rotationsLeft--;

            if (rotation.Direction == Direction.Right)
            {
                newDial++;
            }
            else
            {
                newDial--;
            }

            if (newDial == 100)
            {
                newDial = 0;
            }
            else if (newDial == -1)
            {
                newDial = 99;
            }
        }

        return newDial;
    }

    private IList<Rotation> ConvertRotations(IList<string> rotations)
    {
        var result = new List<Rotation>(rotations.Count);

        foreach (var rotation in rotations)
        {
            result.Add(new Rotation()
            {
                Direction = rotation[0] == 'R' ? Direction.Right : Direction.Left,
                Number = Int32.Parse(rotation.Substring(1))
            });
        }

        return result;
    }

    private enum Direction
    {
        Right,
        Left
    }
    private struct Rotation
    {
        public Direction Direction { get; init; }
        public int Number { get; init; }

        public override string ToString()
        {
            return $"{Direction}{Number}";
        }
    }
}
