public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            var result = checked(@base * multiplier);
            return result.ToString();
        }
        catch(OverflowException e)
        {
            return "*** Too Big ***";
        }
        
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var result = @base * multiplier;
        return Single.IsInfinity(result) ? "*** Too Big ***" : result.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return checked(salaryBase * multiplier).ToString();
        } catch (OverflowException e)
        {
            return "*** Much Too Big ***";
        }
    }
}
