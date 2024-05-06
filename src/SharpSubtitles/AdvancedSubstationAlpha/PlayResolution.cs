using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// These are the coordinates which define the position of
/// appearing subtitles when playing on a video.
/// </summary>
/// <param name="PlayResX"> This is the X coordinate that defines the position
/// of the subtitle. </param>
/// <param name="PlayResY"> This is the Y coordinate that defines the position
/// of the subtitle. </param>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public record struct PlayResolution(int PlayResX, int PlayResY) : IPlayResolution
{
    /// <summary>
    /// The default X coordinate for subtitles if it's
    /// not specified.
    /// </summary>
    public const int PlayResXDefault = 384;

    /// <summary>
    /// The default Y coordinate for subtitles if it's
    /// not specified.
    /// </summary>
    public const int PlayResYDefault = 288;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="PlayResolution"/>
    /// struct.
    /// </summary>
    /// <param name="x">
    ///   This is the X coordinate that defines the position
    ///   of the subtitle. If the value is <see langword="null"/>,
    ///   then the value is automatically altered to
    ///   <see cref="PlayResXDefault"/>.
    /// </param>
    /// <param name="y">
    ///   This is the Y coordinate that defines the position
    ///   of the subtitle. If the value is <see langword="null"/>,
    ///   then the value is automatically altered to
    ///   <see cref="PlayResYDefault"/>.
    /// </param>
    public PlayResolution(int? x, int? y) : this(x ?? PlayResXDefault, y ?? PlayResYDefault)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayResolution"/>
    /// struct.
    /// </summary>
    public PlayResolution() : this(PlayResXDefault, PlayResYDefault)
    {
    }

    /// <summary>
    /// Returns the combined hash code for <see cref="PlayResX"/> and
    /// <see cref="PlayResY"/>.
    /// </summary>
    /// <returns>
    /// The hash code. A hash code is an integer which identifies
    /// differences/instances of a class/struct. This allows quick
    /// comparison or searching because all you need is an integer.
    /// This is also useful in <see cref="Hashtable"/>.
    /// </returns>
    public readonly override int GetHashCode()
    {
        return HashCode.Combine(PlayResX, PlayResY);
    }

    /// <summary>
    /// This method is used internally to display the
    /// string representation of this <see cref="PlayResolution"/>
    /// instance in a debugger, such as Visual Studio's
    /// Watch List/Autos/Locals window.
    /// </summary>
    /// <returns>
    /// A string representation of this <see cref="PlayResolution"/> instance.
    /// </returns>
    private readonly string GetDebuggerDisplay()
    {
        return ToString() ?? string.Empty;
    }

    /// <summary>
    /// Returns a string representation of this <see cref="PlayResolution"/>
    /// instance.
    /// </summary>
    /// <returns>
    /// A string. Example:
    /// <code>
    ///     PlayResX: 384
    ///     PlayResY: 288
    /// </code>
    /// </returns>
    public readonly override string ToString()
    {
        return $@"PlayResX: {PlayResX}
PlayResY: {PlayResY}";
    }
}
