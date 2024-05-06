using SharpSubtitles.AdvancedSubstationAlpha.Internal;

namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
///   Represents [V4+ Styles] section.
/// </summary>
public class V4PlusStyles
{
    /// <summary>
    ///   The Format fields.
    /// </summary>
    public IEnumerable<string> Format { get; init; }

    /// <summary>
    ///   The Style fields.
    /// </summary>
    public IEnumerable<string> Style { get; init; }

    /// <summary>
    ///   Initializes a new instance of the <see cref="V4PlusStyles"/> class.
    /// </summary>
    /// <param name="sect">
    ///   The [V4+ Styles] section.
    /// </param>
    /// <exception cref="ArgumentException">
    ///   Thrown when the V4+ Styles section is invalid.
    /// </exception>
    public V4PlusStyles(Section sect)
    {
        string content = string.Join("\n",
                                    sect.Content.Replace("\r\n", "\n")
                                    .Split('\n')
                                    .Where(line => !line.StartsWith('[')));

        if (content.Split('\n')
            .Where(line => !string.IsNullOrWhiteSpace(line)).Count() != 2)
        {
            throw new ArgumentException(
                $"The section can only have two rows: Format and Style.\nRaw content:\n{content}",
                nameof(sect));
        }

        string[] lines = content.Split('\n');
        Format = lines[0].CutColumnTypeGroup().Split(',').Select(line => line.Trim());
        Style = lines[1].CutColumnTypeGroup().Split(',').Select(line => line.Trim());
    }

    /// <summary />
    public V4PlusStyles() : this(new Section(
        @"[V4+ Styles]
Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding
Style: Default,Arial,16,&Hffffff,&Hffffff,&H0,&H0,0,0,0,0,100,100,0,0,1,1,0,2,10,10,10,1",
        "[V4+ Styles]"))
    {
    }

    /// <summary />
    public V4PlusStyleInfo StyleInformation => new(
            Format.Contains("Name") ? Style.ElementAt(0) : null,
            Format.Contains("Fontname") ? Style.ElementAt(1) : null,
            Format.Contains("Fontsize") ? Style.ElementAt(2) : null,
            Format.Contains("PrimaryColour") ? Style.ElementAt(3) : null,
            Format.Contains("SecondaryColour") ? Style.ElementAt(4) : null,
            Format.Contains("OutlineColour") ? Style.ElementAt(5) : null,
            Format.Contains("BackColour") ? Style.ElementAt(6) : null,
            Format.Contains("Bold") ? Convert.ToBoolean(Style.ElementAt(7)) : null,
            Format.Contains("Italic") ? Convert.ToBoolean(Style.ElementAt(8)) : null,
            Format.Contains("Underline") ? Convert.ToBoolean(Style.ElementAt(9)) : null,
            Format.Contains("StrikeOut") ? Convert.ToBoolean(Style.ElementAt(10)) : null,
            Format.Contains("ScaleX") ? Convert.ToInt32(Style.ElementAt(11)) : null,
            Format.Contains("ScaleY") ? Convert.ToInt32(Style.ElementAt(12)) : null,
            Format.Contains("Spacing") ? Convert.ToInt32(Style.ElementAt(13)) : null,
            Format.Contains("Angle") ? Convert.ToInt32(Style.ElementAt(14)) : null,
            Format.Contains("BorderStyle") ? Convert.ToInt32(Style.ElementAt(15)) : null,
            Format.Contains("Outline") ? Convert.ToInt32(Style.ElementAt(16)) : null,
            Format.Contains("Shadow") ? Convert.ToInt32(Style.ElementAt(17)) : null,
            Format.Contains("Alignment") ? Convert.ToInt32(Style.ElementAt(18)) : null,
            Format.Contains("MarginL") ? Convert.ToInt32(Style.ElementAt(19)) : null,
            Format.Contains("MarginR") ? Convert.ToInt32(Style.ElementAt(20)) : null,
            Format.Contains("MarginV") ? Convert.ToInt32(Style.ElementAt(21)) : null,
            Format.Contains("Encoding") ? Convert.ToInt32(Style.ElementAt(22)) : null);
}
