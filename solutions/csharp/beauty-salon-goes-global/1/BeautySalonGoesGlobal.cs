using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        String rid = RuntimeInformation.RuntimeIdentifier;
        DateTime parsedAppointment = DateTime.Parse(appointmentDateDescription);
        TimeZoneInfo info = GetSystemTimeZone(location);
  
        return TimeZoneInfo.ConvertTimeToUtc(parsedAppointment, info);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        if (alertLevel == AlertLevel.Early)
        {
            return appointment - TimeSpan.FromDays(1);
        }
        if (alertLevel == AlertLevel.Standard)
        {
            return appointment - (TimeSpan.FromHours(1) + TimeSpan.FromMinutes(45));
        }
        return appointment - TimeSpan.FromMinutes(30);
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        DateTime dtCpy = dt - TimeSpan.FromDays(7);
        TimeZoneInfo tz = GetSystemTimeZone(location);
        while(dtCpy <= dt)
        {
            if (tz.IsDaylightSavingTime(dtCpy))
            {
                return true;
            }
            dtCpy += TimeSpan.FromDays(1);
        }
        return false;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo ci = GetLocationCulture(location);
        try
        {
            return DateTime.Parse(dtStr, ci.DateTimeFormat);
        } catch(FormatException e)
        {
            return new DateTime(1, 1, 1, 0, 0, 0);
        }
    }

    private static TimeZoneInfo GetSystemTimeZone(Location location)
    {
        String rid = RuntimeInformation.RuntimeIdentifier;
        if(rid.Contains("win"))
        {
            return TimeZoneInfo.FindSystemTimeZoneById(GetWindowsTimeZoneId(location));
        }
        return TimeZoneInfo.FindSystemTimeZoneById(GetLinuxAndMacOsTimeZoneId(location));
    }

    private static CultureInfo GetLocationCulture(Location location)
    {
        if(location == Location.NewYork)
        {
            return new CultureInfo("en-US");
        }
        if(location == Location.London)
        {
            return new CultureInfo("en-GB");
        }
        return new CultureInfo("fr-FR");
    }

    private static string GetWindowsTimeZoneId(Location location)
    {
        switch(location)
        {
            case Location.NewYork:
                return "Eastern Standard Time";
            case Location.London:
                return "GMT Standard Time";
            case Location.Paris:
                return "W. Europe Standard Time";
            default:
                return "";
        }
    }

    private static string GetLinuxAndMacOsTimeZoneId(Location location)
    {
        switch(location)
        {
            case Location.NewYork:
                return "America/New_York";
            case Location.London:
                return "Europe/London";
            case Location.Paris:
                return "Europe/Paris";
            default:
                return "";
        }
    }
}
