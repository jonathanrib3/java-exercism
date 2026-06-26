static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0m) {
            return 3.213f;
        }
        if (balance >= 0m && balance < 1000m) {
            return 0.5f;
        }
        if (balance >= 1000m && balance < 5000m) {
            return 1.621f;
        }
        return 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)(InterestRate(balance)/ 100.0f);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var annualBalance = 0m;
        var actualBalance = balance;
        var index = 0;
        while(actualBalance < targetBalance) {
          actualBalance = AnnualBalanceUpdate(actualBalance);
          index++;
        }

        return index;
    }
}
