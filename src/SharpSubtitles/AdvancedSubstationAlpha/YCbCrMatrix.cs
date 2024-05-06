namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// Represents the possible value of "YCbCr Matrix" column
/// under the "Script Info" section.
/// </summary>
public enum YCbCrMatrix
{
    /// <summary>
    /// If the YCbCr matrix is set to None or Guess, it is automatically
    /// set to an appropriate value. If width is greater than 1280
    /// or height is greater than 576, <see cref="Bt709"/> is used.
    /// Otherwise, <see cref="Bt601"/> is used. SharpSubtitles doesn't
    /// automatically choose BT.709 or BT.601 because it has no access
    /// to the video and thus can't query information about video resolution.
    /// </summary>
    None,

    /// <summary>
    /// If the YCbCr matrix is set to None or Guess, it is automatically
    /// set to an appropriate value. If width is greater than 1280
    /// or height is greater than 576, <see cref="Bt709"/> is used.
    /// Otherwise, <see cref="Bt601"/> is used. SharpSubtitles doesn't
    /// automatically choose BT.709 or BT.601 because it has no access
    /// to the video and thus can't query information about video resolution.
    /// </summary>
    Guess,

    /// <summary>
    /// Equivalent to the <code>TV.601</code> value.
    /// </summary>
    Tv601,

    /// <summary>
    /// Equivalent to the <code>TV.709</code> value.
    /// </summary>
    Tv709,

    /// <summary>
    /// Equivalent to the <code>BT.601</code> value.
    /// </summary>
    Bt601,

    /// <summary>
    /// Equivalent to the <code>BT.709</code> value.
    /// </summary>
    Bt709,

    /// <summary>
    /// Equivalent to the <code>PC.601</code> value.
    /// </summary>
    Pc601,

    /// <summary>
    /// Equivalent to the <code>PC.709</code> value.
    /// </summary>
    Pc709,

    /// <summary>
    /// Equivalent to the <code>TV.240m</code> value.
    /// </summary>
    Tv240M,

    /// <summary>
    /// Equivalent to the <code>PC.601m</code> value.
    /// </summary>
    Pc240M,

    /// <summary>
    /// Equivalent to the <code>TV.fcc</code> value.
    /// </summary>
    TvFcc,

    /// <summary>
    /// Equivalent to the <code>PC.fcc</code> value.
    /// </summary>
    PcFcc
}
