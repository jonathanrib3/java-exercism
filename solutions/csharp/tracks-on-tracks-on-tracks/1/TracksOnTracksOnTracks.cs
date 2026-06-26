public static class Languages
{
    public static List<string> NewList() => new List<string>();

    public static List<string> GetExistingLanguages() => new List<string>(new string[] {"C#", "Clojure", "Elm"});

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        var newList = new List<string>(languages);
        newList.Add(language);
        return newList;
    }

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages.Count == 0)
        {
            return false;
        }
        return languages[0] == "C#" || languages[1] == "C#" && languages.Count == 2 || languages.Count == 3;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);

        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        foreach(string language in languages)
        {
            if(languages.FindAll(element => element == language).Count > 1)
            {
                return false;
            }
        }
        return true;
    }
}
