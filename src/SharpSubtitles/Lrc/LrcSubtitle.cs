namespace SharpSubtitles.Lrc;

/// <summary>
/// Represents an LRC subtitle.
/// </summary>
public record LrcSubtitle(TimeSpan Start, TimeSpan? End, string Text)
{
    /// <inheritdoc cref="object.GetHashCode()" />
    public override int GetHashCode() => HashCode.Combine(Start, End, Text);

    /// <inheritdoc cref="object.ToString()" />
    public override string ToString()
    {
        return $@"{{
    ""start"": ""{Start}"",
    ""end"": {(End.ToString() == string.Empty ? "null" : $"""{End}""")},
    ""text"": ""{Text}""
}}";
    }
}
