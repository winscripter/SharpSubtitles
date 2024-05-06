namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// Represents information about a [V4+ Styles] section.
/// </summary>
/// <param name="Name"></param>
/// <param name="Fontname"></param>
/// <param name="Fontsize"></param>
/// <param name="PrimaryColour"></param>
/// <param name="SecondaryColour"></param>
/// <param name="OutlineColour"></param>
/// <param name="BackColour"></param>
/// <param name="Bold"></param>
/// <param name="Italic"></param>
/// <param name="Underline"></param>
/// <param name="StrikeOut"></param>
/// <param name="ScaleX"></param>
/// <param name="ScaleY"></param>
/// <param name="Spacing"></param>
/// <param name="Angle"></param>
/// <param name="BorderStyle"></param>
/// <param name="Outline"></param>
/// <param name="Shadow"></param>
/// <param name="Alignment"></param>
/// <param name="MarginL"></param>
/// <param name="MarginR"></param>
/// <param name="MarginV"></param>
/// <param name="Encoding"></param>
public record V4PlusStyleInfo(
    string? Name = "Default",
    string? Fontname = "Arial",
    string? Fontsize = "16",
    string? PrimaryColour = "&Hffffff",
    string? SecondaryColour = "&Hffffff",
    string? OutlineColour = "&H0",
    string? BackColour = "&H0",
    bool? Bold = false,
    bool? Italic = false,
    bool? Underline = false,
    bool? StrikeOut = false,
    int? ScaleX = 100,
    int? ScaleY = 100,
    int? Spacing = 0,
    int? Angle = 0,
    int? BorderStyle = 1,
    int? Outline = 1,
    int? Shadow = 0,
    int? Alignment = 2,
    int? MarginL = 10,
    int? MarginR = 10,
    int? MarginV = 10,
    int? Encoding = 1)
{
    /// <inheritdoc cref="object.GetHashCode()" />
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Name);
        hashCode.Add(Fontname);
        hashCode.Add(Fontsize);
        hashCode.Add(PrimaryColour);
        hashCode.Add(SecondaryColour);
        hashCode.Add(OutlineColour);
        hashCode.Add(BackColour);
        hashCode.Add(Bold);
        hashCode.Add(Italic);
        hashCode.Add(Underline);
        hashCode.Add(StrikeOut);
        hashCode.Add(ScaleX);
        hashCode.Add(ScaleY);
        hashCode.Add(Spacing);
        hashCode.Add(Angle);
        hashCode.Add(BorderStyle);
        hashCode.Add(Outline);
        hashCode.Add(Shadow);
        hashCode.Add(Alignment);
        hashCode.Add(MarginL);
        hashCode.Add(MarginR);
        hashCode.Add(MarginV);
        hashCode.Add(Encoding);
        return hashCode.ToHashCode();
    }
}
