public class Gauge : IGauge
{
    public int FailureCounter { get; private set; } = 0;
    public float FailurePercentage => FailureCounter / (float)_maxFailures;
    public int MaxFailures => _maxFailures;

    public bool Warning => FailureCounter >= _maxFailures - _fromMaxFailures;

    private readonly int _maxFailures;
    private readonly int _fromMaxFailures;

    public Gauge(int maxFailures, int fromMaxFailures)
    {
        _maxFailures = maxFailures;
        _fromMaxFailures = fromMaxFailures;
    }

    public void Add()
    {
        FailureCounter++;
        if (FailureCounter > _maxFailures)
            FailureCounter = _maxFailures;
    }

    public void Subtract()
    {
        FailureCounter--;
        if (FailureCounter < 0)
            FailureCounter = 0;
    }
}
