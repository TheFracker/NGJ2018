public class Locator
{
    private static IAudio _audio;
    private static IGauge _gauge;
    
    public static void Initialize()
    {
        _audio = new Audio();
        _gauge = new Gauge(10, 2);
    }

    public static IAudio GetAudio()
    {
        return _audio;
    }

    public static IGauge GetGauge()
    {
        return _gauge;
    }

    public static void Provide(IAudio audio)
    {
        _audio = audio;
    }

    public static void Provide(IGauge gauge)
    {
        _gauge = gauge;
    }
}
