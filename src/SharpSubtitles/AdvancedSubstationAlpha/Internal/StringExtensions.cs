namespace SharpSubtitles.AdvancedSubstationAlpha.Internal;

internal static class StringExtensions
{
    public static ScriptType ToScriptType(this string value)
        => value is "v4.00+" or "V4.00+"
        ? ScriptType.V400Plus
        : throw new ArgumentException(
            $"Invalid script type (got \"{value}\")", nameof(value));

    public static YCbCrMatrix ToYCbCrMatrix(this string value)
        => value switch
        {
            "guess" => YCbCrMatrix.Guess,
            "TV.601" => YCbCrMatrix.Tv601,
            "TV.709" => YCbCrMatrix.Tv709,
            "BT.601" => YCbCrMatrix.Bt601,
            "BT.709" => YCbCrMatrix.Bt709,
            "PC.601" => YCbCrMatrix.Pc601,
            "PC.709" => YCbCrMatrix.Pc709,
            "TV.240m" => YCbCrMatrix.Tv240M,
            "PC.240m" => YCbCrMatrix.Pc240M,
            "TV.fcc" => YCbCrMatrix.TvFcc,
            "PC.fcc" => YCbCrMatrix.PcFcc,
            "none" or _ => YCbCrMatrix.None
        };

    public static string CutColumnTypeGroup(this string s)
    {
        if (s.StartsWith("Dialogue: ")) s = s[10..];
        if (s.StartsWith("Style: ")) s = s[7..];
        if (s.StartsWith("Format: ")) s = s[8..];

        return s;
    }
}
