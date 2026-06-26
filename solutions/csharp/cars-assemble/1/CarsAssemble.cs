static class AssemblyLine
{
    const int CarsProducedByHour = 221;
    const double CarsProducedByMinute = CarsProducedByHour/60.0;
    public static double SuccessRate(int speed)
    {
        if  (speed >= 1 && speed <= 4) {
            return 1.0;
        }
        if (speed >= 5 && speed <= 8) {
            return 0.9;
        }
        if (speed == 9) {
            return 0.8;
        }
        if (speed == 10) {
            return 0.77;
        }
        return 0;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        var total = speed * CarsProducedByHour;
        if (speed <= 4) {
            return total;
        }
        var faultyCarsRate = 1.0 - SuccessRate(speed);
        return total - total * faultyCarsRate;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)ProductionRatePerHour(speed)/60;
    }
}
