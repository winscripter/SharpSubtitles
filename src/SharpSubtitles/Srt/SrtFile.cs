using SharpSubtitles.Internal;
using System.Text;

namespace SharpSubtitles.Srt;

/// <summary>
/// Represents an SRT subtitle file.
/// </summary>
public struct SrtFile
{
    /// <summary>
    /// All subtitles.
    /// </summary>
    public IEnumerable<SrtSubtitle> Subtitles { get; set; }

    /// <summary>
    ///   Initializes a new instance of the <see cref="SrtFile"/> struct.
    /// </summary>
    /// <param name="rawContent">
    ///   The raw SRT file content.
    /// </param>
    /// <param name="maxDepth">
    ///   The maximum depth, for security purposes.
    /// </param>
    public SrtFile(string rawContent, int maxDepth = 1100)
    {
        var sb = new StringBuilder(rawContent);
        if (!string.IsNullOrWhiteSpace(rawContent.Replace("\r\n", "\n").Split('\n').Last()))
        {
            sb.AppendLine();
        }

        var lineReader = new LineReader(sb.ToString());
        int md = 0; // max depth
        Subtitles = [];

        while (true)
        {
            if (md++ >= maxDepth)
            {
                break;
            }

            try
            {
                Subtitles = Subtitles.Append(SrtSubtitle.Parse(lineReader));
                _ = lineReader.NextLine();
            }
            catch
            {
                break;
            }
        }
    }
}
