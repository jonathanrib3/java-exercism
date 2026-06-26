class WeighingMachine
{
    private int _precision;
    public int Precision{ get; private set; }
    private double _weight;
    public double Weight
    { 
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            _weight = value;
        }
    }
    private double _tareAdjustment;
    public double TareAdjustment { private get; set; } = 5;
    private string _displayWeight;
    public string DisplayWeight
    { 
        get 
        { 
            var precision = $"F{this.Precision}";
            var displayWeight = (this.Weight - this.TareAdjustment).ToString(precision);
            return $"{displayWeight} kg";
        }
    }
    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }
}
