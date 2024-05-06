using SharpSubtitles.Internal;
using System.Text;

namespace SharpSubtitles.Srt;

/// <summary />
public readonly struct SrtSubtitle
{
    /// <summary>
    /// The index of the subtitle, starting with 0.
    /// </summary>
    public readonly int Index { get; init; }

    /// <summary>
    /// The start timestamp of the subtitle- that is, when the
    /// subtitle appears.
    /// </summary>
    public readonly TimeSpan StartTimestamp { get; init; }

    /// <summary>
    /// The end timestamp of the subtitle.
    /// </summary>
    public readonly TimeSpan EndTimestamp { get; init; }

    /// <summary>
    /// The text displayed on the subtitle.
    /// </summary>
    public readonly string Text { get; init; }

    /// <summary />
    /// <param name="index"></param>
    /// <param name="startTimestamp"></param>
    /// <param name="endTimestamp"></param>
    /// <param name="text"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public SrtSubtitle(int index, TimeSpan startTimestamp, TimeSpan endTimestamp, string? text)
    {
        if (index <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index), "Value can't be less than 1");
        }

        if (startTimestamp >= endTimestamp || startTimestamp < TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(
                nameof(startTimestamp), "Value can't be greater than or equal to parameter endTimestamp, and it can't be negative.");
        }

        Index = index;
        StartTimestamp = startTimestamp;
        EndTimestamp = endTimestamp;
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }

    internal static SrtSubtitle Parse(LineReader lineReader, int maxDepth = 1100)
    {
        int index = Convert.ToInt32(lineReader.CurrentLine);
        string timestamps = lineReader.NextLine();

        TimeSpan startTimestamp
            = timestamps.Split([" --> "], StringSplitOptions.None).First().ToTimeSpan(',');
        TimeSpan endTimestamp
            = timestamps.Split([" --> "], StringSplitOptions.None).Last().ToTimeSpan(',');

        var subtitles = new StringBuilder();
        string currentSubtitle = lineReader.NextLine();
        int md = 0; // max depth
        
        while (!string.IsNullOrWhiteSpace(currentSubtitle) && !string.IsNullOrEmpty(currentSubtitle))
        {
            if (md++ > maxDepth)
            {
                throw new InvalidOperationException(
                    "Reached max depth, e.g. maximum allowed subtitles. To allow more subtitles, please alter the maxDepth parameter to a larger value (default is 1100).");
            }

            subtitles.AppendLine(currentSubtitle);
            currentSubtitle = lineReader.NextLine();
        }

        return new SrtSubtitle(index, startTimestamp, endTimestamp, subtitles.ToString());
    }
}
