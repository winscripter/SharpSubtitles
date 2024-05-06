using SharpSubtitles.AdvancedSubstationAlpha.Internal;

namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// Represents the [Script Info] section.
/// </summary>
public readonly struct ScriptInfoSection
{
    /// <summary>
    /// The version of the script.
    /// </summary>
    public readonly ScriptType ScriptType { get; init; }

    /// <summary>
    /// The coordinates for the captions.
    /// </summary>
    public readonly PlayResolution PlayResolution { get; init; }

    /// <summary />
    public readonly bool ScaledBorderAndShadow { get; init; }

    /// <summary>
    /// The YCbCr matrix.
    /// </summary>
    public readonly YCbCrMatrix YCbCrMatrix { get; init; }

    private ScriptInfoSection(ScriptType scriptType,
        PlayResolution playResolution,
        bool scaledBorderAndShadow,
        YCbCrMatrix yCbCrMatrix)
    {
        ScriptType = scriptType;
        PlayResolution = playResolution;
        ScaledBorderAndShadow = scaledBorderAndShadow;
        YCbCrMatrix = yCbCrMatrix;
    }

    /// <summary />
    public ScriptInfoSection()
    {
        ScriptType = ScriptType.V400Plus;
        PlayResolution = new PlayResolution(384, 288);
        ScaledBorderAndShadow = true;
        YCbCrMatrix = YCbCrMatrix.None;
    }

    /// <summary />
    public static ScriptInfoSection Parse(Section section)
    {
        if (section.Name != "[Script Info]")
            throw new ArgumentException("Section name must be \"[Script Info]\".",
                nameof(section));

        var data = Section.ParseContent(section.Content);
        return new ScriptInfoSection(
            scriptType: data["ScriptType"].ToScriptType(),
            playResolution: new PlayResolution(
                Convert.ToInt32(data["PlayResX"]), Convert.ToInt32(data["PlayResY"])),
            scaledBorderAndShadow: data["ScaledBorderAndShadow"] == "yes",
            yCbCrMatrix: data["YCbCr Matrix"].ToYCbCrMatrix());
    }

    /// <inheritdoc cref="object.ToString()" />
    public override string ToString()
    {
        return $@"{{
    ""scriptType"": {ScriptType},
    ""playResX"": {PlayResolution.PlayResX},
    ""playResY"": {PlayResolution.PlayResY},
    ""scaledBorderAndShadow"": {ScaledBorderAndShadow},
    ""yCbCrMatrix"": {YCbCrMatrix}
}}";
    }
}
