namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// Represents an abstraction for <see cref="PlayResolution"/>.
/// </summary>
public interface IPlayResolution
{
    /// <summary>
    /// This is the X coordinate that defines the position
    /// of the subtitle.
    /// </summary>
    int PlayResX { get; }

    /// <summary>
    /// This is the Y coordinate that defines the position
    /// of the subtitle.
    /// </summary>
    int PlayResY { get; }
}