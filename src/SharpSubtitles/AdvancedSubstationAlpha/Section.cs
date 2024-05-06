using System.Collections.Frozen;

namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// Represents a section in the ASS subtitle format. This is a way
/// to categorize different settings, such as texts, margins, etc.
/// ASS supports the preceding sections:
/// <list type="bullet">
///     <item>
///         [Script Info]
///     </item>
///     <item>
///         [V4+ Styles]
///     </item>
///     <item>
///         [Events]
///     </item>
/// </list>
/// </summary>
public class Section
{
    private readonly string m_Content;
    private readonly string m_Name;

    /// <summary />
    public Section(string content, string name)
    {
        m_Content = string.Join("\n", content
                                    .Replace("\r\n", "\n")
                                    .Split('\n')
                                    .Where(line => !line.StartsWith(';') || string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                                    .ToArray());
        m_Name = name;
    }

    /// <summary>
    /// The content of the section.
    /// </summary>
    public string Content => m_Content;

    /// <summary>
    /// The name of the section.
    /// </summary>
    public string Name => m_Name;

    internal static FrozenDictionary<string, string> ParseContent(string content)
    {
        var keyValuePairs = new HashSet<KeyValuePair<string, string>>();

        var lines = content.Split('\n');
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            if (parts.Length == 2)
            {
                var key = parts[0].Trim();
                var value = parts[1].Trim();
                keyValuePairs.Add(new KeyValuePair<string, string>(key, value));
            }
        }

        return FrozenDictionary.ToFrozenDictionary(keyValuePairs);
    }
}
