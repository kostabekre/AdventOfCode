public class FileLogger : ILogger
{
    private const string LOG_PATH = "log.txt";

    private StreamWriter sw;
    public FileLogger()
    {
        sw = new StreamWriter(LOG_PATH);
    }


    public void Log(string line)
    {
        sw.WriteLine(line);
    }
    public void Dispose()
    {
        sw.Close();
    }
}


