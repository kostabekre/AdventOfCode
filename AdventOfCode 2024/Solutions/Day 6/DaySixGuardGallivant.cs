using Xunit.Abstractions;

namespace Solutions.Day_6;

internal record SearchResult(HashSet<Coordinate> Coordinates, bool WasBreakFromLoop);
public class DaySixGuardGallivant : ISolution
{
    public static char GuardCharacter = '^';
    private static char ObstacleCharacter = '#';
    private readonly char[][] _map;
    private readonly Coordinate _startPosition;
    private readonly ITestOutputHelper _output;

    public DaySixGuardGallivant(DaySixArgs args, ITestOutputHelper output)
    {
        _output = output;
        _map = args.Map;
        _startPosition = args.StartPosition;
    }

    public int SolveFirstPart()
    {
        var visited = GetAllPossiblePositions(_map);

        // add one, because last position wasn't added.
        return visited.Coordinates.Count;
    }

    private SearchResult GetAllPossiblePositions(char[][] map, bool breakIfLong = false)
    {
        var currentPosition = _startPosition;

        var direction = Directions.Up;

        var visited = new HashSet<Coordinate> { currentPosition };

        var newPositionIsNotAddedTimes = 0;

        while (!breakIfLong || breakIfLong && newPositionIsNotAddedTimes <= 100)
        {
            var nextPosition = GetNextPosition(currentPosition, direction);
            var isInside = isInsideTerritory(nextPosition, direction, map);
            if (isInside == false)
            {
                break;
            }

            var nextCharacter = GetCharacter(nextPosition, map);
            if (nextCharacter == ObstacleCharacter)
            {
                direction = GetNextDirection(direction);
            }
            else
            {
                if (visited.Contains(currentPosition) == false)
                {
                    visited.Add(currentPosition);
                    newPositionIsNotAddedTimes = 0;
                }
                else
                {
                    newPositionIsNotAddedTimes++;
                }
                currentPosition = nextPosition;
            }
        }

        visited.Add(currentPosition);

        return new SearchResult(visited, newPositionIsNotAddedTimes >= 25);
    }

    private Coordinate GetNextPosition(Coordinate coordinate, Directions direction)
    {
        switch (direction)
        {
            case Directions.Up:
                return new Coordinate(coordinate.X, coordinate.Y - 1);
            case Directions.Right:
                return new Coordinate(coordinate.X + 1, coordinate.Y);
            case Directions.Down:
                return new Coordinate(coordinate.X, coordinate.Y + 1);
            case Directions.Left:
                return new Coordinate(coordinate.X - 1, coordinate.Y);
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

    private bool isInsideTerritory(Coordinate nextPosition, Directions direction, char[][] map)
    {
        switch (direction)
        {
            case Directions.Up:
                return map.Length + nextPosition.Y >= map.Length;
            case Directions.Right:
                return map[0].Length - (nextPosition.X + 1) >= 0;
            case Directions.Down:
                return map.Length - (nextPosition.Y + 1) >= 0;
            case Directions.Left:
                return map[0].Length + nextPosition.X >= map.Length;
            default:
                throw new ArgumentException("Unknown direction");
        }
    }

    private char GetCharacter(Coordinate nextPosition, char[][] map)
    {
        return map[nextPosition.Y][nextPosition.X];
    }

    public int SolveSecondPart()
    {
        var possiblePositions = GetAllPossiblePositions(_map).Coordinates.Except(new[] { _startPosition }).ToArray();

        var foundedLoops = 0;

        foreach (var position in possiblePositions)
        {
            _output.WriteLine($"Solving for obstacle {position}");
            
            var wasForceBreak = GetAllPossiblePositions(GetMapWithNewObstacle(position), true).WasBreakFromLoop;

            if (wasForceBreak)
            {
                foundedLoops++;
            }
        }
        
        return foundedLoops;
    }

    private char[][] GetMapWithNewObstacle(Coordinate obstacleCoordinate)
    {
        var map = new List<char[]>(_map.Length);

        for (int i = 0; i < _map.Length; i++)
        {
            var originalLine = _map[i];
            var newLine = new List<char>(originalLine.Length);
            
            for (int j = 0; j < originalLine.Length; j++)
            {
                if (obstacleCoordinate.X == j && obstacleCoordinate.Y == i)
                {
                    newLine.Add(ObstacleCharacter);
                }
                else
                {
                    newLine.Add(originalLine[j]);
                }
            }
            
            map.Add(newLine.ToArray());
        }
        
        return map.ToArray();
    }
}