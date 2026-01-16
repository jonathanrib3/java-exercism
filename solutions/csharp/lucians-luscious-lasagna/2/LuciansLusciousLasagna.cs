class Lasagna
{
    public const int EXPECTED_MINUTES_IN_OVEN = 40;
    public const int LAYER_COOKING_MINUTES = 2;

    public int ExpectedMinutesInOven() => EXPECTED_MINUTES_IN_OVEN;

    public int RemainingMinutesInOven(int actualMinutes) => EXPECTED_MINUTES_IN_OVEN - actualMinutes;

    public int PreparationTimeInMinutes(int layers) => LAYER_COOKING_MINUTES * layers;

    public int ElapsedTimeInMinutes(int layers, int minutesPast) => PreparationTimeInMinutes(layers) + minutesPast;
}
