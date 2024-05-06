namespace SharpSubtitles.Internal;

internal class LineReader(string contents)
{
    private readonly string[] _lfSeparatedContent
        = contents.Replace("\r\n", "\n").Split('\n');

    private int _index = 0;

    public string NextLine()
    {
        if (_index < _lfSeparatedContent.Length)
        {
            return _lfSeparatedContent[++_index];
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public bool IsEndOfLine() => _index >= _lfSeparatedContent.Length;
    public string CurrentLine => _lfSeparatedContent[_index];
}
