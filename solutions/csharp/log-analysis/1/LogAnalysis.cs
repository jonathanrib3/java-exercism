public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delim)
    {    
        var indexOfDelim = str.IndexOf(delim) + delim.Length;
        return str.Substring(indexOfDelim);
    }

    public static string SubstringBetween(this string str, string delim1, string delim2)
    {
        var startIndex = str.IndexOf(delim1) + delim1.Length;
        var substringFromStartIndex = str.Substring(startIndex);
        var splittedArr = substringFromStartIndex.Split(delim2);
        return splittedArr[0];
    }
    
    public static string Message(this string str) => str.Split(new string[] {": "}, StringSplitOptions.None)[1];

    public static string LogLevel(this string str) => str.Split(new char[] {'[', ']'})[1];
}