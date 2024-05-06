using SharpSubtitles.Internal;
using System.Globalization;

namespace SharpSubtitles.Lrc;

internal class LrcParserCore(string contents)
{
    private readonly LineReader _reader = new(contents);

    public List<LrcSubtitle> Parse(int maxDepth = 1100)
    {
        var subtitles = new List<LrcSubtitle>();
        int depth = 0;

        try
        {
            while (!_reader.IsEndOfLine())
            {
                if (depth++ > maxDepth) throw new InvalidOperationException("Max depth reached.");
                string line = _reader.CurrentLine;

                var start = EatBrackets();
                var end = EatBrackets();

                subtitles.Add(new LrcSubtitle(start ?? TimeSpan.Zero, end, line));

                _ = _reader.NextLine();

                TimeSpan? EatBrackets()
                {
                    if (!line.StartsWith('[')) return null;

                    line = line[1..];
                    int closeBracketIndex = line.IndexOf(']');
                    string betweenBrackets = line[..closeBracketIndex];
                    string[] colonSplit = betweenBrackets.Split(':');
                    string minutes = colonSplit[0];
                    string secondsMilliseconds = colonSplit[1];
                    int intMinutes = Convert.ToInt32(minutes);
                    double seconds = Convert.ToDouble(
                        secondsMilliseconds, CultureInfo.InvariantCulture);
                    line = line[8..];
                    if (line.FirstOrDefault() == ']')
                        line = line[1..];
                    return TimeSpan.FromSeconds(seconds * (intMinutes + 1));
                }
            }
        }
        catch
        {
        }

        return subtitles;
    }
}
