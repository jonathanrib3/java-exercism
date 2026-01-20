static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var formattedId = id == null ? "" : $"[{id}] - ";
        var formattedDept = department == null ? "OWNER" : department.ToUpper();
        return $"{formattedId}{name} - {formattedDept}";
    }
}
