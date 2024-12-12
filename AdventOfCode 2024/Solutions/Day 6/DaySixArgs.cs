namespace Solutions.Day_6;

/// <summary>
/// Arguments for day 6.
/// </summary>
/// <param name="Map">2d dimensional representation of the map.</param>
/// <param name="Position">X (second array of map) and Y (first array of map) coordinates of guard</param>
public record DaySixArgs(char[][] Map, Coordinate StartPosition);