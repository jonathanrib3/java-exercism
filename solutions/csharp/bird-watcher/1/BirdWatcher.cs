class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => birdsPerDay[birdsPerDay.Length - 1];

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int birdCount in birdsPerDay)
        {
            if(birdCount == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        var acc = 0;
        for(int i = 0; i < numberOfDays; i++)
        {
            acc += birdsPerDay[i];
        }
        return acc;
    }

    public int BusyDays()
    {
        var busyDays = 0;
        foreach(int birdCount in birdsPerDay)
        {
            if(birdCount >= 5)
            {
                busyDays++;
            }
        }
        return busyDays;
    }
}
