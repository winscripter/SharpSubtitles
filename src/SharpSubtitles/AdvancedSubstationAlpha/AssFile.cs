using SharpSubtitles.Internal;

namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// An ASS file (Advanced SubStation Alpha) is a caption
/// format.
/// </summary>
public class AssFile
{
    /// <summary>
    /// Represents a subtitle.
    /// </summary>
    /// <param name="Start"></param>
    /// <param name="End"></param>
    /// <param name="Text"></param>
    public record SubtitleAppearance(
        TimeSpan Start, TimeSpan End, string Text);

    /// <summary>
    /// The Script Info section contains global information about
    /// the ASS file, such as position, YCbCr matrix, etc.
    /// </summary>
    public ScriptInfoSection ScriptInfoSection { get; init; }

    /// <summary>
    /// The V4+ Styles section contains information about the
    /// caption appearance, such as background color, text font,
    /// borders, margins, etc.
    /// </summary>
    public V4PlusStyles V4PlusStylesSection { get; init; }

    /// <summary>
    /// The Events section contains actual captions and their
    /// start-end timestamps.
    /// </summary>
    public Events EventsSection { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AssFile"/> class.
    /// </summary>
    /// <param name="content"></param>
    public AssFile(string content)
    {
        string[] text = content.Replace("\r\n", "\n").Split('\n');

        var sections = new List<List<string>>();
        var currentSection = new List<string>();

        foreach (var line in text)
        {
            if (line.StartsWith('['))
            {
                if (currentSection.Count > 0)
                {
                    sections.Add(currentSection);
                    currentSection = [];
                }
            }

            currentSection.Add(line);
        }

        if (currentSection.Count > 0)
        {
            sections.Add(currentSection);
        }

        var sectionStrings = sections.Select(section => string.Join("\n", section)).ToArray();

        string scriptInfo = sectionStrings[0];
        string v4Plus = sectionStrings[1];
        string eventsSection = sectionStrings[2];

        ScriptInfoSection = ScriptInfoSection.Parse(new Section(scriptInfo, "[Script Info]"));
        V4PlusStylesSection = new V4PlusStyles(new Section(v4Plus, "[V4+ Styles]"));
        EventsSection = new Events(eventsSection);
    }

    /// <summary />
#pragma warning disable CS8618
    public AssFile()
#pragma warning restore CS8618
    {
        ScriptInfoSection = new ScriptInfoSection();
        V4PlusStylesSection = new V4PlusStyles();
    }

    /// <summary />
    /// <returns />
    public IEnumerable<SubtitleAppearance> GetSubtitles()
    {
        foreach (var evt in EventsSection.Dialogues!)
        {
            yield return new SubtitleAppearance(
                evt.ElementAt(1).ToTimeSpan(),
                evt.ElementAt(2).ToTimeSpan(),
                evt.ElementAt(8)[1..]);
        }
    }
}
