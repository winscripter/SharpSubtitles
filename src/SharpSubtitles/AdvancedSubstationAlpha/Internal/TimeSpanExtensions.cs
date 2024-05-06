namespace SharpSubtitles.AdvancedSubstationAlpha.Internal;

internal static class TimeSpanExtensions
{
    public static string Stringify(this TimeSpan value)
    {
        string hours = value.Hours.ToString().PadLeft(2, '0');
        string minutes = value.Minutes.ToString().PadLeft(2, '0');
        string seconds = value.Seconds.ToString().PadLeft(2, '0');
        string mseconds = value.Milliseconds.ToString().PadLeft(2, '0');

        return $"{hours}:{minutes}:{seconds}.{mseconds}";
    }
}
