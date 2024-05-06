namespace SharpSubtitles.Lrc;

/// <summary />
public class LrcFile
{
    /// <summary />
    public IEnumerable<LrcSubtitle> Subtitles { get; set; }

    /// <summary />
    public LrcFile(string rawContent, int maxDepth = 5) : this(rawContent)
        => Subtitles = new LrcParserCore(rawContent).Parse(maxDepth);

    /// <summary />
    public LrcFile(string rawContent)
    {
        Subtitles = new LrcParserCore(rawContent).Parse();
    }

#pragma warning disable CS8618
    internal LrcFile() { }
#pragma warning restore CS8618
}
