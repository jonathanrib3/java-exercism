public enum AccountType
{
    Guest = Permission.Read,
    User = Permission.Read | Permission.Write,
    Moderator = Permission.All
}

[Flags]
public enum Permission : byte
{
    Read = 0b001,
    Write = 0b010,
    Delete = 0b100,
    All = Read | Write | Delete,
    None = 0b000
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        switch(accountType)
        {
            case AccountType.Guest:
                return (Permission) AccountType.Guest;
            case AccountType.User:
                return (Permission) AccountType.User;
            case AccountType.Moderator:
                return (Permission) AccountType.Moderator;
            default:
                return Permission.None;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return (Permission) (current & ~(revoke));
    }

    public static bool Check(Permission current, Permission check)
    {
        return current >= check;
    }
}
