using System.Runtime.CompilerServices;

namespace SolutionTests.Helpers;

public static class TestFileHelper
{
    public static string ReadFileAsString(string file, [CallerFilePath]string filePath = "") {
        var directoryPath = Path.GetDirectoryName(filePath);
        var fullPath = Path.Join(directoryPath, file);
        return File.ReadAllText(fullPath);
    }
}