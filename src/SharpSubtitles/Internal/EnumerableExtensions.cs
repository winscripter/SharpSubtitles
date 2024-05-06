namespace SharpSubtitles.Internal;

internal static class EnumerableExtensions
{
    // source: https://stackoverflow.com/a/1290638/21072788
    // CC BY-SA 2.5
    public static int IndexOf<T>(this IEnumerable<T> source, T value)
    {
        int index = 0;
        var comparer = EqualityComparer<T>.Default; // or pass in as a parameter
        foreach (T item in source)
        {
            if (comparer.Equals(item, value)) return index;
            index++;
        }
        return -1;
    }
}
