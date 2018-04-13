public class Locator
{
    private static IAudio _audio;
    
    public static void Initialize()
    {
        _audio = new Audio();
    }

    public static IAudio GetAudio()
    {
        return _audio;
    }

    public static void Provide(IAudio audio)
    {
        _audio = audio;
    }
}
