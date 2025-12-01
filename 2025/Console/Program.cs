using System.Reflection;
using Solutions.Day1;

string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input.txt");

var lines = System.IO.File.ReadAllLines(path);

var answer = new Day1SecretEntarance().GetNumberOfAllRotations(lines);

Console.WriteLine(answer);
