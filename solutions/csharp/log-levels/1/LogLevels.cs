static class LogLine
{
    public static string Message(string logLine)
    {
        var IndexOfSplitter = logLine.IndexOf(": ");
        return logLine.Substring(IndexOfSplitter + 1).Trim();
    }

    public static string LogLevel(string logLine)
    {
        return logLine.Split(new char[] {'[', ']'})[1].ToLower();
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}
