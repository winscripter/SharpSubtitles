namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// Parses the
/// </summary>
public class Events
{
    /// <summary />
    public IEnumerable<string>? Format { get; private set; }

    /// <summary />
    public IEnumerable<IEnumerable<string>>? Dialogues { get; private set; }

    /// <summary />
    /// <param name="content"></param>
    public Events(string content)
    {
        ParseContent(content);
    }

    /// <summary />
    /// <param name="content"></param>
    private void ParseContent(string content)
    {
        string[] lines = content.Replace("\r\n", "\n").Split('\n');
        bool isEventsSection = false;
        var dialogues = new List<IEnumerable<string>>();

        foreach (var line in lines)
        {
            if (line.StartsWith("[Events]"))
            {
                isEventsSection = true;
            }
            else if (isEventsSection)
            {
                if (line.StartsWith("Format: "))
                {
                    Format = line["Format: ".Length..].Split(',').Select(s => s.Trim());
                }
                else if (line.StartsWith("Dialogue: "))
                {
                    var dialogue = line["Dialogue: ".Length..]
                        .Split([','], 9) // Split by the first 9 commas only
                        .Select(s => s.Trim());
                    dialogues.Add(dialogue);
                }
            }
        }

        Dialogues = dialogues;
    }
}
