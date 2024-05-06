namespace SharpSubtitles.Internal;

internal static class StringExtensions
{
    public static TimeSpan ToTimeSpan(this string duration, char separator = '.')
    {
        string[] splitted = duration.Split(':');

        string hours = splitted[0];
        string minutes = splitted[1];

        string[] s = splitted[2].Split(separator);

        string seconds = s[0];
        string milliseconds = s[1];

        int i_hours = int.Parse(hours);
        int i_minutes = int.Parse(minutes);
        int i_seconds = int.Parse(seconds);
        int i_milliseconds = int.Parse(milliseconds);

        return new TimeSpan(i_hours / 24, i_hours, i_minutes, i_seconds, i_milliseconds);
    }
}
