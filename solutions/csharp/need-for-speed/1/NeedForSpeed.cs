class RemoteControlCar
{
    public int speed;
    public int batteryDrain;
    public int battery;
    private int _distanceDriven;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.battery = 100;
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        this._distanceDriven = 0;
    }

    public bool BatteryDrained() => battery - batteryDrain < 0;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if(!BatteryDrained()) {
            _distanceDriven += speed;
            battery -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);

    public int MaxDrivenDistance() => (battery / batteryDrain) * speed;
}

class RaceTrack
{
    public int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car) => car.MaxDrivenDistance() >= distance;
}
