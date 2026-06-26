public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var phoneNumberChunks = phoneNumber.Split("-");
        return (
            IsNewYork: phoneNumberChunks[0] == "212",
            IsFake: phoneNumberChunks[1] == "555",
            LocalNumber: phoneNumberChunks[2]
        );
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
