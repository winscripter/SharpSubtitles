using System.Numerics;

namespace SharpSubtitles.AdvancedSubstationAlpha;

/// <summary>
/// Represents a Hex color.
/// </summary>
/// <param name="r">The R field.</param>
/// <param name="g">The G field.</param>
/// <param name="b">The B field.</param>
public struct Hex(byte r, byte g, byte b) : IEquatable<Hex>,
    IEqualityOperators<Hex, Hex, bool>,
    IParsable<Hex>,
    ICloneable
{
    /// <summary>
    /// The R field.
    /// </summary>
    public byte R { get; set; } = r;

    /// <summary>
    /// The G field.
    /// </summary>
    public byte G { get; set; } = g;

    /// <summary>
    /// The B field.
    /// </summary>
    public byte B { get; set; } = b;
    
    /// <inheritdoc cref="IParsable{TSelf}.Parse(string, IFormatProvider?)" />
    public static Hex Parse(string s, IFormatProvider? formatProvider = null)
    {
        s = s.Length == 1 ? new string(s.First(), 6) : s;

        return new Hex(
            Convert.ToByte($"0x{s[0]}{s[1]}", 16),
            Convert.ToByte($"0x{s[2]}{s[3]}", 16),
            Convert.ToByte($"0x{s[4]}{s[5]}", 16));
    }

    /// <inheritdoc cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)" />
    public static bool TryParse(string? s, IFormatProvider? formatProvider, out Hex result)
    {
        try
        {
            result = Parse(s ?? throw new NullReferenceException());
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }

    /// <inheritdoc cref="ValueType.Equals(object?)" />
    public override readonly bool Equals(object? obj)
    {
        return obj is Hex hex &&
               R == hex.R &&
               G == hex.G &&
               B == hex.B;
    }

    /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
    public readonly bool Equals(Hex other)
    {
        return Equals((object)other);
    }

    /// <inheritdoc cref="ValueType.GetHashCode()" />
    public override readonly int GetHashCode()
    {
        return HashCode.Combine(R, G, B);
    }

    /// <summary>
    ///   Checks whether two instances of <see cref="Hex"/> have the same
    ///   value or not.
    /// </summary>
    /// <param name="left">
    ///   The left-hand-side instance.
    /// </param>
    /// <param name="right">
    ///   The right-hand-side instance.
    /// </param>
    /// <returns>
    ///   A boolean, indicating whether two instances of <see cref="Hex"/>
    ///   have the same value or not.
    /// </returns>
    public static bool operator ==(Hex left, Hex right)
    {
        return left.Equals(right);
    }

    /// <summary>
    ///   Checks whether two instances of <see cref="Hex"/> do not have the same
    ///   value or not.
    /// </summary>
    /// <param name="left">
    ///   The left-hand-side instance.
    /// </param>
    /// <param name="right">
    ///   The right-hand-side instance.
    /// </param>
    /// <returns>
    ///   A boolean, indicating whether two instances of <see cref="Hex"/>
    ///   have a different value or not.
    /// </returns>
    public static bool operator !=(Hex left, Hex right)
    {
        return !(left == right);
    }

    /// <inheritdoc cref="ICloneable.Clone()" />
    public readonly object Clone() => this;
}
